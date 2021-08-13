using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _4_Repeat_.ConveyorOfRequestProcessing.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next += next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await _next?.Invoke(context);

            if (context.Response.StatusCode == 404)
            {
                await context.Response.WriteAsync("ITS HANDLING 404 ERROR (PAGE NOT FOUND)");
            }
            else if (context.Response.StatusCode == 403)
            {
                await context.Response.WriteAsync("ITS HANDLING 403 ERROR (ACCESS DANIED)");
            }
        }
    }
}
