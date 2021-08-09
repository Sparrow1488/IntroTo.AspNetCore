using _3_Repeat_.CreateMiddleware.Middlewares;
using _4_Repeat_.ConveyorOfRequestProcessing.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace _4_Repeat_.ConveyorOfRequestProcessing
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<AuthorizationMiddleware>();
            app.UseMiddleware<RoutingMiddleware>();
        }
    }
}
