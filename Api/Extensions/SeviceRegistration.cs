using Data.Repositories;
using Domain.Providers;
using Domain.Repositories;

namespace Api.Extensions;

internal static class ServiceRegistration
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IProductService, ProductService>();
        
        return services;
    }
}