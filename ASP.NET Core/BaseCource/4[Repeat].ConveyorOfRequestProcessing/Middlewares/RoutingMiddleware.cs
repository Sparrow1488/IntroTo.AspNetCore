using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4_Repeat_.ConveyorOfRequestProcessing.Middlewares
{
    public class RoutingMiddleware
    {
        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public readonly RequestDelegate _next;

        public async Task InvokeAsync(HttpContext context)
        {
            string requestPath = context.Request.Path.Value;
            if (requestPath == "/home")
            {
                await context.Response.WriteAsync("Home page");
            }
            else if (requestPath == "/store")
            {
                await context.Response.WriteAsync("Store page");
            }
            else
            {
                context.Response.StatusCode = 404; // page not found
            }
        }
    }
}
