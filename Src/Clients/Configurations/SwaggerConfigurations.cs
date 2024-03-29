using System.Reflection;
using Microsoft.OpenApi.Models;

namespace NerdStore.Clients.Configurations
{
    public static class SwaggerConfigurations
    {
        public static void AddSwaggerConfigurations(
            this IServiceCollection services,
            IConfiguration configuration
        ) {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Clients",
                    Version = "1.0",
                    Description = "A API for clients things.",
                    Contact = new OpenApiContact() { Name = "Zaqueu", Email = "zaqueudovale@gmail.com" },
                    TermsOfService = new Uri("https://docs.github.com"),
                    License = new OpenApiLicense() { Name = "License", Url = new Uri("https://opensource.org/licenses/MIT") }
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });

                options.DescribeAllParametersInCamelCase();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            })
            .AddSwaggerGenNewtonsoftSupport();
        }
    }
}
