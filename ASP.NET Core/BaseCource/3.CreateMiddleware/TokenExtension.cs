using _3.CreateMiddleware.middlewares;
using Microsoft.AspNetCore.Builder;

namespace _3.CreateMiddleware
{
    // бабахаем это для метода расширения IApplicationBuilder
    public static class TokenExtension
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string pattern)
        {
            return builder.UseMiddleware<TokenMiddleware>(pattern);
        }
    }
}
