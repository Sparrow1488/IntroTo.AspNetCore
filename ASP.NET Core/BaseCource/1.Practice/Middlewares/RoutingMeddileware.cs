using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _1.Practice.Middlewares
{
    public class RoutingMeddileware
    {
        private RequestDelegate _next;

        public RoutingMeddileware(RequestDelegate next)
        {
            _next = next;
        }

        private HttpContext _context;
        public async Task InvokeAsync(HttpContext context)
        {
            _context = context;
            var requestPath = context.Request.Path.Value;
            if (requestPath == "/")
                await NavigationHome();
            else if (requestPath == "/amsterdam")
                await NavigationAmsterdam();
            else
                context.Response.StatusCode = 404;
        }
        private async Task NavigationHome()
        {
            await _context.Response.WriteAsync("<b>HOME</b>");
        }
        private async Task NavigationAmsterdam()
        {
            await _context.Response.WriteAsync("<b>ABOUT AMSTERDAM</b>");
        }
    }
}
