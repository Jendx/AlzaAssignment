using Data.Context;
using Data.Extensions;
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
using Microsoft.Extensions.Logging;

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

        builder.Services.UseDataMsSql();
        
        using var appHost = builder.Build();
        var queueConsumer = appHost.Services.GetRequiredService<IQueueConsumer<UpdateProductDto>>();
    
        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = factory.CreateLogger("Program");
        await queueConsumer.SubscribeAsync(async (dto) =>
        {
            try
            {
                ArgumentNullException.ThrowIfNull(dto.Stock);
                var productService = appHost.Services.GetRequiredService<IProductService>();
                await productService.UpdateProductStockAsync(dto.Id, dto.Stock.Value);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error occured during updating consumed product {id}", dto.Id);
                throw;
            }
            
        });
        
        await appHost.RunAsync();
    }
}