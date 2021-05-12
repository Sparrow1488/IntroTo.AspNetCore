using _3.CreateMiddleware.middlewares;
using Microsoft.AspNetCore.Builder;

namespace _3.CreateMiddleware
{
    public static class AuthExtension
    {
        public static IApplicationBuilder UserAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationMiddleware>();
        }
    }
}
