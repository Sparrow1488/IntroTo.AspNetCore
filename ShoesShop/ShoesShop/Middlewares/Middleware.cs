using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ShoesShop.Middlewares
{
    public abstract class Middleware
    {
        protected RequestDelegate _next;
        public Middleware(RequestDelegate next)
        {
            _next = next;
        }
        public abstract Task InvokeAsync(HttpContext context);
    }
}
