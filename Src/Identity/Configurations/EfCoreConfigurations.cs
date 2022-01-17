using Microsoft.EntityFrameworkCore;
using NerdStore.Identity.Database;

namespace NerdStore.Identity.Configurations
{
    public static class EfCoreConfigurations
    {
        public static void AddEfCoreConfigurations(
            this IServiceCollection services,
            IConfiguration configuration
        ) {
            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Connection"));
                options.UseSnakeCaseNamingConvention();
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
