using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _1.Practice.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private HttpContext _context;
        public async Task InvokeAsync(HttpContext context)
        {
            _context = context;
            await _next.Invoke(context);
            if (context.Response.StatusCode == 404)
                await Handling404Error();
            if (context.Response.StatusCode == 403)
                await Handling403Error();
        }
        private async Task Handling404Error()
        {
            await _context.Response.WriteAsync("OH NOOOOO!!!!! ERROR 404  =  page not found");
        }
        private async Task Handling403Error()
        {
            await _context.Response.WriteAsync("OH NOOOOO!!!!! ERROR 403  =  access denied");
        }
    }
}
