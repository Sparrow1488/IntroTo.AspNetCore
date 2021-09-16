using _11.Configuration.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace _11.Configuration
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }

        public Startup(IConfiguration config)
        {
            var builder = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                {"color", "blue"},
                {"text", "Hello ASP.NET 5"}
            })
            .AddJsonFile("config.json")
            .AddJsonFile("man.json")
            .AddConfiguration(config); // добавление конфигурации по умолчанию 
            
            AppConfiguration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(provider => AppConfiguration);
            services.Configure<Man>(AppConfiguration);
            services.Configure<Man>(options => options.Age = options.Age < 0 ? 0 : options.Age);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<ManMiddleware>();
            app.UseMiddleware<ConfigMiddleware>(); 
        }
    }
}
