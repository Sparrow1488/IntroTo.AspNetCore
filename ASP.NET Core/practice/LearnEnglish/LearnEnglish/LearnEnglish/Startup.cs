using LearnEnglish.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnEnglish
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => UseSqlServer(options));
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //    options.OnAppendCookie = cookieContext =>
            //      CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
            //    options.OnDeleteCookie = cookieContext =>
            //      CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
            //});

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //    {
            //        options.Cookie.SameSite = SameSiteMode.None;
            //        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            //        options.Cookie.IsEssential = true;
            //    });

            //services.AddSession(options =>
            //{
            //    options.Cookie.SameSite = SameSiteMode.None;
            //    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            //    options.Cookie.IsEssential = true;
            //});
            services.AddRazorPages();
        }

        private void CheckSameSite(HttpContext httpContext, CookieOptions options)
        {
            if (options.SameSite == SameSiteMode.None)
                options.SameSite = SameSiteMode.Unspecified;
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseStaticFiles();

            //app.UseCookiePolicy();
            //app.UseAuthentication();
            //app.UseAuthorization();
            //app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        private DbContextOptionsBuilder UseSqlServer(DbContextOptionsBuilder builder)
        {
            return builder.UseSqlServer(Configuration.GetConnectionString("BaseConnection"));
        }
    }
}
