using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _13.Sessions
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();                                  // подключение самих сессий
            services.AddDistributedMemoryCache(); // для хранения сессий в памяти
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSession(); // подключаем в конвеер обработки запроса

            app.Run(async context =>
            {
                string sessionKey = "login";
                string login = context.Session.GetString(sessionKey);
                if (string.IsNullOrWhiteSpace(login))
                {
                    context.Session.SetString(sessionKey, "User");
                    await context.Response.WriteAsync("Hello ASP.NET Core 5");
                }
                else await context.Response.WriteAsync("Hello, " + context.Session.GetString(sessionKey));
            });
        }
    }
}
