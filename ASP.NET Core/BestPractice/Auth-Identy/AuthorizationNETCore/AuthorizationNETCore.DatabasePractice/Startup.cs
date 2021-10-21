using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace AuthorizationNETCore.DatabasePractice
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAuthentication("Cookie").AddCookie("Cookie", config => 
            {
                config.LoginPath = "/Home/Login";
                config.AccessDeniedPath = "/Home/AccessDenied";
            });
            services.AddAuthorization(config =>
            {
                config.AddPolicy("User", configurePolicy => configurePolicy.RequireClaim(ClaimTypes.Role, "User"));
                config.AddPolicy("Admin", configurePolicy => configurePolicy.RequireClaim(ClaimTypes.Role, "Admin"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}
