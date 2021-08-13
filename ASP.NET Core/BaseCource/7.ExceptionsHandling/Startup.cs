using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace _7.ExceptionsHandling
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            env.EnvironmentName = "Production";

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.Map("/error", ap => ap.Run(async context =>
            {
                await context.Response.WriteAsync("DivideByZeroException occured!");
            }));

            app.Run(async (context) =>
            {
                int x = 0;
                int y = 8 / x;
                await context.Response.WriteAsync($"Result = {y}");
            });
        }
    }
}
