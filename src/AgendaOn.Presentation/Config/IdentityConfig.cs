using AgendaOn.Infra.Data.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AgendaOn.Presentation.Config
{
    public static class IdentityConfig
    {
        public static void Identity(this IServiceCollection services, IConfiguration configuration)
        {
                     

            services.AddDbContext<IdentityContext>
                (opt => opt.UseSqlite(configuration
                .GetConnectionString("IdentityConnection")));


            services.AddIdentity<IdentityUser, IdentityRole>()
                 .AddEntityFrameworkStores<IdentityContext>()
                 .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                                      

            });

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Auth/forbidden";
                options.Cookie.Name = "AgendaOn";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Auth/Autenticar";
                // ReturnUrlParameter requires 
                //using Microsoft.AspNetCore.Authentication.Cookies;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
                                
            });

        }
    }
}
