using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _3.CreateMiddleware.middlewares
{
    // при создании собственных middleware, необходимо, чтобы они содержали:
    // 1. Конструктор с параметром RequestDelegate
    // 2. Метод Invoke or InvokeAsync, принимающие HttpContext (которые возвращают Task 99%)
    public class TokenMiddleware
    {
        private RequestDelegate _next;
        private string _pattern;
        public TokenMiddleware(RequestDelegate next, string pattern)
        {
            _next = next;
            _pattern = pattern;
        }
        // метод обрабатывает запрос если че
        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if(token != _pattern)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("TI CHE DURAK????");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
