using _10.ServicesLifetime.Middlewares;
using _10.ServicesLifetime.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace _10.ServicesLifetime
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICounter, RandomCounter>();
            services.AddTransient<TimeService>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<TimeMiddleware>();
            app.UseMiddleware<CounterMiddleware>();
            app.Run(async context => {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
