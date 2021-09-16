using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace _11.Configuration.Middlewares
{
    public class ManMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<Man> _man;

        public ManMiddleware(RequestDelegate next, IOptions<Man> man)
        {
            _next = next;
            _man = man;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value == "/man")
                await context.Response.WriteAsync($"<p>Name{_man.Value.Name}.</p>");
            else await _next.Invoke(context);
        }
    }
}
