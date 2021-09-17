using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace _14.Routing.Middlewares
{
    public class RouteMiddleware
    {
        private readonly RequestDelegate _next;
        public RouteMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IRouter router)
        {
            var rContext = new RouteContext(context);
            rContext.RouteData.Routers.Add(router);

            // проверка соответствия строки запроса маршруту
            await router.RouteAsync(rContext);
        }
    }
}
