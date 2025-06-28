using CqrsTemplate.Application.Common.Interfaces;
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

        // Service Product (urusan ke External Api)
        services.AddScoped<IExternalProductService, ExternalProductService>();

        return services;
    }
}
