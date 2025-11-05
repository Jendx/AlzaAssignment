using Data.Repositories;
using Domain.Constants;
using Domain.DTOs;
using Domain.Messaging;
using Domain.Providers;
using Domain.Repositories;
using DotNetEnv;
using KafkaJob.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KafkaJob;

internal static class Program
{
    public static async Task Main()
    {
        var builder = Host.CreateApplicationBuilder();
        
        Env.TraversePath().Load();
        var port = Environment.GetEnvironmentVariable("KAFKA_PORT");
        ArgumentException.ThrowIfNullOrWhiteSpace(port);
        
        var host = Environment.GetEnvironmentVariable("KAFKA_HOST");
        ArgumentException.ThrowIfNullOrWhiteSpace(host);
        builder.Services.AddSingleton<IQueueConsumer<UpdateProductDto>>(new KafkaQueueConsumer<UpdateProductDto>($"{host}:{port}", Topics.PRODUCT_TOPIC));
        builder.Services
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IProductService, ProductService>();

        using var appHost = builder.Build();
        await appHost.RunAsync();
        
        var queueConsumer = appHost.Services.GetRequiredService<IQueueConsumer<UpdateProductDto>>();
        var productService = appHost.Services.GetRequiredService<IProductService>();
        await queueConsumer.SubscribeAsync(async (dto) =>
        {
            ArgumentNullException.ThrowIfNull(dto.Stock);
            await productService.UpdateProductStockAsync(dto.Id, dto.Stock.Value);
        });
    }
}