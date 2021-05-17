using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace _6.StaticFiles
{
    public class Startup
    {
        // wwwroot - простая папка с таким названием
        // если нас не устраивает такая папка, то создаем новую и ее путь запердываем в класс Program в метод CreateHostBuilder()
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
