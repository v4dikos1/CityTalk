using Application.Abstractions;
using Application.Abstractions.DaData;
using Infrastructure.Services;
using Infrastructure.Services.DaData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceRegistrar
{
    public static IServiceCollection RegisterExternalInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IPasswordService, PasswordService>();
        services.AddScoped<IEmailService, ConfirmationEmailService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddSingleton<IVerificationService, VerificationService>();
        services.AddScoped<ICurrentHttpContextAccessor, CurrentHttpContextAccessor>();
        services.AddTransient<IDaDataService, DaDataService>();
        return services;
    }
}