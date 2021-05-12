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
                // ��� ��� ����� ���������� � ������ TokenExtension
                builder.UseToken("1488");

                // ������� ������ TokenMiddleware
                // ���� � ���, ��� ��� ���������� UseMiddleware() � ����������� TokenMiddleware
                // ������� ������� ���������� �������, ������� �� ��������� � app.Run(async context) - �.�. �����
                builder.Run(async context =>
                {
                    await context.Response.WriteAsync("Auth by token!!!");
                });
            });
            
        }
    }
}
