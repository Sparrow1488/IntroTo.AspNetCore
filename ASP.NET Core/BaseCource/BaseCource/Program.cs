using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace BaseCource
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Че происходит");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // при желании класс Startup можно заменить на любой другой (но зачем)
                    webBuilder.UseStartup<Startup>();
                });
    }
}
