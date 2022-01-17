using Newtonsoft.Json.Converters;

namespace NerdStore.Identity.Configurations
{
    public static class ControllersConfigurations
    {
        public static void AddControllersConfigurations(this IServiceCollection services)
        {
            services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });
        }
    }
}
