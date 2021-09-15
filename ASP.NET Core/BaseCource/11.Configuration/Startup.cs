using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace _11.Configuration
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            //var builder = new ConfigurationBuilder()
            //    .AddInMemoryCollection(new Dictionary<string, string>
            //    {
            //        {"firstname", "Sparrow"},
            //        {"age", "17"}
            //    });
            //AppConfiguration = builder.Build();

            var builder = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                {"color", "blue"},
                {"text", "Hello ASP.NET 5"}
            })
            .AddJsonFile("config.json");
            AppConfiguration = builder.Build();
        }
        public IConfiguration AppConfiguration { get; set; }

        public void Configure(IApplicationBuilder app)
        {
            var color = AppConfiguration["color"];
            var text = AppConfiguration["text"];
            app.Run(async (context) =>
            {
                // в JSON (как и XML), можно использовать большую вложенность, главное - указывать путь до значения через двоеточие и ключи
                await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>" +
                    $"<br>" +
                    $"<p>Author: {AppConfiguration["author:name"]}</p><br>" +
                    $"<p>Rating: {AppConfiguration["author:rating"]}</p><br>" +
                    $"<p>Application: {AppConfiguration["application:title"]}</p><br>" +
                    $"<p>Status: {AppConfiguration["application:status"]}</p><br>" +
                    $"<p>Date create: {AppConfiguration["dateCreate"]}</p><br>");
            });
        }
    }
}
