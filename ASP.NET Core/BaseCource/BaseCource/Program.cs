using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace BaseCource
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("�� ����������");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // ��� ������� ����� Startup ����� �������� �� ����� ������ (�� �����)
                    webBuilder.UseStartup<Startup>();
                });
    }
}
