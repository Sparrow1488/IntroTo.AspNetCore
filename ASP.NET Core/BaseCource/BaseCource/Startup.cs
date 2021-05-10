using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BaseCource
{
    /*
     * ��������� ������� � ASP.NET Core �������� �� �������� ���������. 
     * ������� ������ ������� �������� ������ ��������� � ���������, � ����� ��������� �� �������� ������ HTTP-������� ������� ���������� � ��� �����. 
     * ��� ���������� ���������, ������� �������� �� ��������� �������, ���������� middleware. 
     * � ASP.NET Core ��� ����������� ����������� middleware ������������ ����� Configure �� ������ Startup.
     */
    public class Startup
    {
        private IWebHostEnvironment _environment;
        // ��� Empty �������, ����������� � ������ Startup ����� �����������, ������ ��� ����� ������� �������
        // � ��� ������������� (�.�. ��������� ������������) ������������ ��� ������
        public Startup(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        // �����, ������� ��������� ���������� ��������� ������� (�� ����������)
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // �������������, ��� ���������� ����� ������������ ������ (������������)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ���� ���������� � ����������, �� ������� ����� �� ����
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // ��������� ����������� ������������� (� ���������� ��� ��������� ��� �����)
            app.UseRouting();

            // ������������� ������, ������� ����� ��������������
            app.UseEndpoints(endpoints =>
            {
                // ���������, ��� ��� ��������� �� ������� "/" (�������� �����) ...
                endpoints.MapGet("/", async context =>
                {
                    // ����� ���������� ���������:
                    await context.Response.WriteAsync("Hello ASP.NET Core 5!");
                });
                endpoints.MapGet("/about", async context =>
                {
                    await context.Response.WriteAsync($"Application use : {_environment.ApplicationName}");
                });
            });

            // ���������� ��� �������, ������� �� ���� ���������� ����� (�� � ��� �����)
            app.Run(async context =>
            {
                await context.Response.WriteAsync("We can't processing your request!!!!!!!");
            });
        }
    }
}
