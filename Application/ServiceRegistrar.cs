using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Behaviors;
using FluentValidation;
using MediatR;

namespace Application;

public static class ServiceRegistrar
{
    public static IServiceCollection RegisterUseCasesServices(
        this IServiceCollection services)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);

        return services;
    }
}