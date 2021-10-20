using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace AuthorizationNETCore.Roles
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string scheme = "Cookie";
            services.AddControllersWithViews();
            services.AddAuthentication(scheme).AddCookie(scheme, config =>
            {
                config.LoginPath = "/Admin/Login";
                config.AccessDeniedPath = "/Home/AccessDenied";
            });
            services.AddAuthorization(options =>
            {

                // Policy является устаревшим методом авторизации и уступает тем же Claims по гибкости и актульности
                options.AddPolicy("Administrator", config => config.RequireClaim(ClaimTypes.Role, "Administrator"));
                //options.AddPolicy("Manager", config => config.RequireClaim(ClaimTypes.Role, "Manager")); 

                options.AddPolicy("Manager", config =>
                    config.RequireAssertion(handler => 
                        handler.User.HasClaim(ClaimTypes.Role, "Administrator") ||
                        handler.User.HasClaim(ClaimTypes.Role, "Manager")));

                // Можно трактовать политику следующим образом: добавить политику, при которой права доступа "Manager"
                //  может получить пользователь в случае, если его роль либо "Administrator", либо "Manager"

                // Также можно добавить и другие условия получения прав доступа: возраст, дата, время, прочие условия
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}
