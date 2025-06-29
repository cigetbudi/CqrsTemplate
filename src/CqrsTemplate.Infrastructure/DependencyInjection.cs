using CqrsTemplate.Application.Common.Interfaces;
using CqrsTemplate.Infrastructure.Common.ExternalApiLogging;
using CqrsTemplate.Infrastructure.Common.Library;
using CqrsTemplate.Infrastructure.Common.Tracing;
using CqrsTemplate.Infrastructure.Persistence;
using CqrsTemplate.Infrastructure.Persistence.Repositories;
using CqrsTemplate.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsTemplate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // Koneksi db
        services.AddSingleton<DbConnectionFactory>();

        // Repo Product (urusan ke DB)
        services.AddScoped<IProductRepository, ProductRepository>();
        // Repo Logging (ke db juga)
        services.AddScoped<ILoggingRepository, LoggingRepository>();
        services.AddScoped<IExternalApiLoggingRepository, ExternalApiLoggingRepository>();

        // Service Product (urusan ke External Api)
        services.AddScoped<IExternalProductService, ExternalProductService>();


        // Library
        // Tracer
        services.AddScoped<ITracer, Tracer>();
        services.AddTransient<HttpClientTracingHandler>();
        services.AddTransient<ExternalApiLoggingHandler>();

        services.AddHttpClient("ExternalApi")
            .AddHttpMessageHandler<ExternalApiLoggingHandler>()
            .AddHttpMessageHandler<HttpClientTracingHandler>();

        services.AddScoped<ILibrary, Library>();

        return services;
    }
}
