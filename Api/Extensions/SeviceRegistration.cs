using Data.Messaging;
using Data.Repositories;
using Domain.Constants;
using Domain.DTOs;
using Domain.Messaging;
using Domain.Providers;
using Domain.Repositories;

namespace Api.Extensions;

internal static class ServiceRegistration
{
    public static IServiceCollection RegisterDataServices(this IServiceCollection services)
    {
        services
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IProductService, ProductService>();
        
        return services;
    }

    public static IServiceCollection UseKafkaProducer(this IServiceCollection services)
    {
        var port = Environment.GetEnvironmentVariable("KAFKA_PORT");
        ArgumentException.ThrowIfNullOrWhiteSpace(port);

        var host = Environment.GetEnvironmentVariable("KAFKA_HOST");
        ArgumentException.ThrowIfNullOrWhiteSpace(host);
        services.AddSingleton<IQueueProducer<UpdateProductDto>>(
            new KafkaQueueProducer<UpdateProductDto>($"{host}:{port}", Topics.PRODUCT_TOPIC));

        return services;
    }
}