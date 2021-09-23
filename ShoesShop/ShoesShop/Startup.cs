using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ShoesShop.Middlewares;
using ShoesShop.Services;
using ShoesShop.Services.Builders;

namespace ShoesShop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPagesStorage, PagesStorage>();
            services.AddTransient<IProductPageBuilder, ProductPageBuilder>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            app.UseMiddleware<ProductsMiddleware>();

            app.Run(async context =>
            {
                string errorHtml = await new PagesStorage().GetHtmlAsync("errors/page404.html");
                await context.Response.WriteAsync(errorHtml);
            });
        }
    }
}
