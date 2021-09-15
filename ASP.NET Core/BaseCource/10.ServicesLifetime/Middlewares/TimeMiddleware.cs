using _10.ServicesLifetime.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _10.ServicesLifetime.Middlewares
{
    public class TimeMiddleware
    {
        private readonly RequestDelegate _next;
        private TimeService _timeService;

        public TimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, TimeService timeService)
        {
            _timeService = timeService;

            if (context.Request.Path.Value.ToLower() == "/time")
                await context.Response.WriteAsync("Actual time : " + _timeService.GetActualTime());
            else
                await _next?.Invoke(context);
        }
    }
}
