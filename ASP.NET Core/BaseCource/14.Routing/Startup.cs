using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace _14.Routing
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);
            routeBuilder.MapRoute("/home", HomeHandle);                             // обработка запроса по адресу /home
            routeBuilder.MapRoute("/index", IndexHandle);
            routeBuilder.MapRoute("default", "{controller}/{action}/{id?}"); // обработка запроса через контроллер / метод / необязательный параметр
            routeBuilder.MapRoute("default", "api/{controller}/{action}");    // обработка через статический сегмент
            app.UseRouter(routeBuilder.Build());

            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/Home", async context =>
            //        await context.Response.WriteAsync("<h3>HOME PAGE</h3>"));
            //    endpoints.MapGet("/Index", async context =>
            //    {
            //        context.Response.ContentType = "text/html";
            //        await context.Response.WriteAsync("<h3>INDEX PAGE</h3>");
            //    });
            //});

            app.Run(async context =>
                await context.Response.WriteAsync("DEFAULT PAGE"));
        }

        public async Task HomeHandle(HttpContext context)
        {
            await context.Response.WriteAsync("HOME!");
        }
        public async Task IndexHandle(HttpContext context)
        {
            await context.Response.WriteAsync("INDEX!!!");
        }
    }
}
