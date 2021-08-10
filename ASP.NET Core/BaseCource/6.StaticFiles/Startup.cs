using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace _6.StaticFiles
{
    public class Startup
    {
        // wwwroot - ������� ����� � ����� ���������
        // ���� ��� �� ���������� ����� �����, �� ������� ����� � �� ���� ����������� � ����� Program � ����� CreateHostBuilder()
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("HIIIIIIIIIIIIIIIIIIIIIIIIIIIIII USEEEEEEEEEEEEERRRRRRRRRRRRRR!!!!!!!!!!!!!!!!!!!!!!!!!");
            });
        }
    }
}