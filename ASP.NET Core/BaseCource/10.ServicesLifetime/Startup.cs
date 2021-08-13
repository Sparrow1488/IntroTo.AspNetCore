using _10.ServicesLifetime.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace _10.ServicesLifetime
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICounter, RandomCounter>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<CounterMiddleware>();
        }
    }
}
