using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class ServiceRegistrar
{
    public static IServiceCollection RegisterDataAccessServices(
        this IServiceCollection services,
        IConfiguration configuration,
        bool isDevelopment)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("CityTalkContext"));
            if (isDevelopment)
            {
                options.EnableSensitiveDataLogging();
            }
        });
        return services;
    }
}