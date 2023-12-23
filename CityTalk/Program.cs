using Application;
using Application.Abstractions.Mapping;
using Domain;
using Infrastructure;
using System.Reflection;
using WebApi;
using WebApi.StartupConfiguration;
using WebApi.StartupConfiguration.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOwnSwagger();
builder.Services.RegisterDataAccessServices(builder.Configuration, builder.Environment.IsDevelopment());
builder.Services.RegisterUseCasesServices();
builder.Services.RegisterExternalInfrastructureServices(builder.Configuration);

builder.Services.ConfigureOptions<EmailOptionsSetup>();
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.Load("Application")));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        build =>
        {
            build
                .AllowAnyOrigin()
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithExposedHeaders("*");
        });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.MapHealthChecks("/healthz");

app.UseCors("AllowAllOrigins");

app.ConfigureSwaggerUi();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();