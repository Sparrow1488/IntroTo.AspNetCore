using _9.MyService.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _9.MyService.Middlewares
{
    public class HomeBuilderMiddleware
    {
        private RequestDelegate _next;

        public HomeBuilderMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, IHomeBuilder homeBuilder)
        {
            await context.Response.WriteAsync(homeBuilder.GetHomeInfo());
        }
    }
}
