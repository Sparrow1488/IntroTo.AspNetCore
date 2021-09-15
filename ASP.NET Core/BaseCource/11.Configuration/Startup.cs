using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace _11.Configuration
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    {"firstname", "Sparrow"},
                    {"age", "17"}
                });
            AppConfiguration = builder.Build();

        }
        public IConfiguration AppConfiguration { get; set; }

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(AppConfiguration["firstname"]);
            });
        }
    }
}
