using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace _3.CreateMiddleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.Map("/auth", builder =>
            {
                builder.UserAuth();
                builder.Run(async context =>
                {
                    await context.Response.WriteAsync("Auth by password!!!");
                });
            });

            app.Map("/token", builder =>
            {
                // это наш метод расширени€ в классе TokenExtension
                builder.UseToken("1488");

                // сначала посети TokenMiddleware
                // соль в том, что при объ€влении UseMiddleware() в конструктор TokenMiddleware
                // не€вным образом внедр€етс€ делегат, который мы объ€вл€ем в app.Run(async context) - т.е. здесь
                builder.Run(async context =>
                {
                    await context.Response.WriteAsync("Auth by token!!!");
                });
            });
            
        }
    }
}
