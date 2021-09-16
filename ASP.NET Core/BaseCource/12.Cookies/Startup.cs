using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;

namespace _12.Cookies
{
    public class Startup
    {
        private string _lastVisitor = "";
        public void Configure(IApplicationBuilder app)
        {
            var rndLogins = new string[] { "Bebra", "Bomba", "Firerer", "Naga" };
            app.Run(async context =>
            {
                string cookieKey = "name";
                if (context.Request.Cookies.ContainsKey(cookieKey))
                    context.Request.Cookies.TryGetValue(cookieKey, out _lastVisitor);
                context.Response.Cookies.Append(cookieKey, rndLogins[new Random().Next(0, rndLogins.Length - 1)]);
                await context.Response.WriteAsync(string.IsNullOrWhiteSpace(_lastVisitor) ? "Hello world!" : "Hello, " + _lastVisitor);
            });
        }
    }
}
