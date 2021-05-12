using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4.ConveyorOfRequestProcessing.middlewares
{
    public class AuthMiddleware
    {
        private RequestDelegate _next;
        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var inputPassword = context.Request.Query["password"];
            if (inputPassword != "1488")
                context.Response.StatusCode = 404;
            else
                await _next.Invoke(context);
        }
    }
}
