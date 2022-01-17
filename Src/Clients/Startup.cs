using NerdStore.Clients.Configurations;

namespace NerdStore.Clients
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
            services.AddControllersConfigurations();

            services.AddSwaggerConfigurations(Configuration);

            services.AddRoutingConfigurations();

            services.AddEfCoreConfigurations(Configuration);
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env
        ) {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity 1.0"));
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseResponseCaching();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(builder =>
            {
                builder.MapControllers();
            });
        }
    }
}
