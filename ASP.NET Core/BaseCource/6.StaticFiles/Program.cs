using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace _6.StaticFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseWebRoot("staticFiles"); // если папка со статик файлами не есть wwwroot, то создаем папку и ее имя пердим сюда
                });
    }
}
