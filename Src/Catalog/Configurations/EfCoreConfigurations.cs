using Microsoft.EntityFrameworkCore;
using NerdStore.Catalog.Database;

namespace NerdStore.Catalog.Configurations
{
    public static class EfCoreConfigurations
    {
        public static void AddEfCoreConfigurations(
            this IServiceCollection services,
            IConfiguration configuration
        ) {
            services.AddDbContext<CatalogContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Connection"));
                options.UseSnakeCaseNamingConvention();
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
