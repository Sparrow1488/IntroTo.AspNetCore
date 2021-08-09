using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_Repeat_.CreateMiddleware.Middlewares
{
    public class AuthorizationMiddleware
    {
        public AuthorizationMiddleware(RequestDelegate nextDelegate)
        {
            _next += nextDelegate;
            SetRegisteredPeople();
        }
        private List<string> _registeredPeople = new List<string>();
        public readonly RequestDelegate _next;

        public async Task InvokeAsync(HttpContext context)
        {
            if(_registeredPeople.Contains(context.Request.Query["name"]))
            {
                await _next?.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 403;
            }
        }
        private void SetRegisteredPeople()
        {
            _registeredPeople = new List<string>()
            {
                "sparrow",
                "gokhlia",
                "kayote"
            };
        }
    }
}
