using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _4.ConveyorOfRequestProcessing.middlewares
{
    public class RoutingMiddleware
    {
        private RequestDelegate _next;
        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var requestPath = context.Request.Path.ToString().ToLower();
            if (requestPath == "/index")
                await context.Response.WriteAsync("Index page");
            else if (requestPath == "/home")
                await context.Response.WriteAsync("Home page");
            else if (requestPath == "/messages")
                await context.Response.WriteAsync("Messages page");
            else context.Response.StatusCode = 404;
        }
    }
}
