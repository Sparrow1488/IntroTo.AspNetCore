using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _4.ConveyorOfRequestProcessing.middlewares
{
    public class AuthMiddleware
    {
        private RequestDelegate _next;
        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var inputPassword = context.Request.Query["password"];
            if (inputPassword != "1488")
                await context.Response.WriteAsync("Access Denied");
            else
                await _next.Invoke(context);
        }
    }
}
