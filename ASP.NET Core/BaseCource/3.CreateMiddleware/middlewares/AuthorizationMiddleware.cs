using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3.CreateMiddleware.middlewares
{
    public class AuthorizationMiddleware
    {
        private RequestDelegate _next;
        private List<string> UsersPasswords = new List<string>(); // ну тупа БД ШООООООООООООООООО
        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
            CreatePasswords();
        }
        private void CreatePasswords()
        {
            UsersPasswords.Add("1337");
            UsersPasswords.Add("1488");
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var password = context.Request.Query["password"];
            var coincidedPas = UsersPasswords.Find(pas => pas == password);
            if (coincidedPas == null)
                await context.Response.WriteAsync("Von s sayta!!!");
            else 
                await _next.Invoke(context);

        }
    }
}
