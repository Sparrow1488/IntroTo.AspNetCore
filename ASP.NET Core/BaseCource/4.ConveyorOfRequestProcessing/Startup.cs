using _4.ConveyorOfRequestProcessing.middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace _4.ConveyorOfRequestProcessing
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            /*
             *  суть в том, что мы не можем посещать странички сайта, если не авторизованы
             *  т.е., мы должны с запросом страницы указать пароль
             *  например: /home?password=1488
             */
            app.UseMiddleware<AuthMiddleware>();
            app.UseMiddleware<RoutingMiddleware>();
        }
    }
}
