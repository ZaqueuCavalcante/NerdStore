namespace NerdStore.Identity.Configurations
{
    public static class AuthorizationConfigurations
    {
        public static void AddAuthorizationConfigurations(this IServiceCollection services)
        {
            services.AddAuthorization();
        }
    }
}
