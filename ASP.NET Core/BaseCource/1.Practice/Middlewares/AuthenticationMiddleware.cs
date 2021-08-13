using _1.Practice.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _1.Practice.Middlewares
{
    public class AuthenticationMiddleware
    {
        private RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAuthentication authService)
        {
            bool wasAuth = authService.Authenticate(context);
            if (wasAuth)
                await _next.Invoke(context);
            else
                context.Response.StatusCode = 403;
        }
    }
}
