using Microsoft.AspNetCore.Identity;
using NerdStore.Identity.Database;

namespace NerdStore.Identity.Configurations
{
    public static class IdentityConfigurations
    {
        public static void AddIdentityConfigurations(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;  // The minimum length.
                options.Password.RequireDigit = true;  // Requires a number between 0-9.
                options.Password.RequireLowercase = true;  // Requires a lowercase character.
                options.Password.RequireUppercase = true;  // Requires an uppercase character.
                options.Password.RequireNonAlphanumeric = true;  // Requires a non-alphanumeric character (@, %, #, !, &, $, ...).
                options.Password.RequiredUniqueChars = 1;  // Requires the minimum number of distinct characters.
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);  // The amount of time a user is locked out when a lockout occurs.
                options.Lockout.MaxFailedAccessAttempts = 3;  // The number of failed access attempts until a user is locked out, if lockout is enabled.
                options.Lockout.AllowedForNewUsers = true;  // Determines if a new user can be locked out.
            });
        }
    }
}
