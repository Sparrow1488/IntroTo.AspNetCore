using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace _5.IWebHostEnvironmentAndOther
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // изменяем в файле launchSettings.json значение "ASPNETCORE_ENVIRONMENT" на "Test"
            app.Run(async (context) =>
            {
                context.Response.Headers["Content-Type"] = "text/html; charset=utf-8";

                if (env.IsEnvironment("Test")) // Если проект в состоянии "Test"
                {
                    await context.Response.WriteAsync("В состоянии тестирования");
                }
                else
                {
                    await context.Response.WriteAsync("В процессе разработки или в продакшене");
                }
            });
        }
    }
}
