using Microsoft.EntityFrameworkCore;
using NerdStore.Cart.Database;

namespace NerdStore.Cart.Configurations
{
    public static class EfCoreConfigurations
    {
        public static void AddEfCoreConfigurations(
            this IServiceCollection services,
            IConfiguration configuration
        ) {
            services.AddDbContext<CartContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Connection"));
                options.UseSnakeCaseNamingConvention();
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
