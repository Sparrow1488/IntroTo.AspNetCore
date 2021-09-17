using _15.CustomRouting.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace _15.CustomRouting
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            var routeBuilder = new RouteBuilder(app);
            routeBuilder.Routes.Add(new HomeRouter());
            app.UseRouter(routeBuilder.Build());

            string indexPage = StaticStorage.GetStaticHtmlAsync("index.html").Result;
            app.Run(async context =>
                await context.Response.WriteAsync(indexPage));
        }
    }
}
