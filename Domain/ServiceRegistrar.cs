using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

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
            options.UseNpgsql(new NpgsqlDataSourceBuilder(configuration.GetConnectionString("CityTalkContext"))
                    .EnableDynamicJson()
                    .Build());
            if (isDevelopment)
            {
                options.EnableSensitiveDataLogging();
            }
        });
        return services;
    }
}