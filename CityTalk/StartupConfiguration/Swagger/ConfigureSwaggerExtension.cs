using Microsoft.OpenApi.Models;

namespace WebApi.StartupConfiguration.Swagger;

public static class ConfigureSwaggerExtension
{
    public static void ConfigureOwnSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("internal", new OpenApiInfo { Title = "CityTalk.EventCreator.Api", Version = "v1" });

            c.OperationFilter<CustomSwaggerOperationAttribute>();
            var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly)
                .ToList();
            xmlFiles.ForEach(xmlFile => c.IncludeXmlComments(xmlFile));
            c.AddSecurityDefinition($"AuthToken",
                new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Name = "Authorization",
                    Description = "Authorization token"
                });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = $"AuthToken",
                        }
                    },
                    new string[] {}
                }
            });
        });
    }

    public static void ConfigureSwaggerUi(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var env = serviceScope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/internal/swagger.json", "CityTalk.EventCreator.Api");
            c.OAuthAppName("Swagger Client");
            c.OAuthUsePkce();
        });
    }
}