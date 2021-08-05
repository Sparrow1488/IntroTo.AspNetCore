using _3_Repeat_.CreateMiddleware.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace _3_Repeat_.CreateMiddleware
{
    public static class AuthorizationExtension
    {
        public static IApplicationBuilder UseAuthorization(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AuthorizationMiddleware>();
        }
    }
}
