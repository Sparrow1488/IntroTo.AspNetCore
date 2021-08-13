using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _10.ServicesLifetime.Middlewares
{
    public class CounterMiddleware
    {
        private int _requestCounter = 0;
        private RequestDelegate _next;

        public CounterMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, ICounter counter)
        {
            _requestCounter++;
            string responseText = string.Format("Request num: {0}; Random value {1}", _requestCounter, counter.Value());
            await context.Response.WriteAsync(responseText);
        }
    }
}
