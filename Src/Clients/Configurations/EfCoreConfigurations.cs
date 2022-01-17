using Microsoft.EntityFrameworkCore;
using NerdStore.Clients.Database;

namespace NerdStore.Clients.Configurations
{
    public static class EfCoreConfigurations
    {
        public static void AddEfCoreConfigurations(
            this IServiceCollection services,
            IConfiguration configuration
        ) {
            services.AddDbContext<ClientsContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Connection"));
                options.UseSnakeCaseNamingConvention();
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
