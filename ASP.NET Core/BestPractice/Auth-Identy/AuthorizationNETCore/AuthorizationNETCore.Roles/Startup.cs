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

                // Policy �������� ���������� ������� ����������� � �������� ��� �� Claims �� �������� � �����������
                options.AddPolicy("Administrator", config => config.RequireClaim(ClaimTypes.Role, "Administrator"));
                //options.AddPolicy("Manager", config => config.RequireClaim(ClaimTypes.Role, "Manager")); 

                options.AddPolicy("Manager", config =>
                    config.RequireAssertion(handler => 
                        handler.User.HasClaim(ClaimTypes.Role, "Administrator") ||
                        handler.User.HasClaim(ClaimTypes.Role, "Manager")));

                // ����� ���������� �������� ��������� �������: �������� ��������, ��� ������� ����� ������� "Manager"
                //  ����� �������� ������������ � ������, ���� ��� ���� ���� "Administrator", ���� "Manager"

                // ����� ����� �������� � ������ ������� ��������� ���� �������: �������, ����, �����, ������ �������
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
