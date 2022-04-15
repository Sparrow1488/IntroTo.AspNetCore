using FormSender.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.Threading.Tasks;

namespace FormSender
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            ConfigureSerilog();
            try
            {
                var host = CreateHostBuilder(args).Build();
                using (var provider = host.Services.CreateScope())
                {
                    await DataInitializer.InitializeAsync(provider.ServiceProvider);
                }
                host.Run();
                return 0;
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, ex.Message);
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void ConfigureSerilog()
        {
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .CreateLogger();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.UseStartup<Startup>());
    }
}
