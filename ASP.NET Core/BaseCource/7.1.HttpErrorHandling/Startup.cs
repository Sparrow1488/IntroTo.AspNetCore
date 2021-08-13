using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace _7._1.HttpErrorHandling
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
             app.UseStatusCodePagesWithReExecute("/error", "?code={0}");

            app.Map("/error", (builder) => builder.Run(async (context) =>
            {
                if(context.Request.Query["code"] == "404")
                {
                    await context.Response.WriteAsync("Well... sorry, page not found");
                }
            }));
        }
    }
}
