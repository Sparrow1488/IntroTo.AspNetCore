using _1.Practice.Middlewares;
using _1.Practice.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace _1.Practice
{
    public class Startup
    {
        /*
         * TODO: 4 странички: главная, про амстердам, канаду и обработка ошибок
         */
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAuthentication, NameAuthentication>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseMiddleware<RoutingMeddileware>();
        }
    }
}
