using Confluent.Kafka;
using Domain.Messaging;
using Microsoft.Extensions.Logging;

namespace KafkaJob.Messaging;

public sealed class KafkaQueueConsumer<TMessage> : IQueueConsumer<TMessage> where TMessage : class 
{
    private readonly IConsumer<Ignore, string> _consumer;
    private readonly ILogger _logger;
    public KafkaQueueConsumer(string bootstrapServer, string topic)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = bootstrapServer,
            GroupId = "kafka-job",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        _consumer.Subscribe(topic);
        
        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        _logger = factory.CreateLogger("Program");
    }
    
    public async Task SubscribeAsync(Func<TMessage, Task> handleMessage, CancellationToken cancellationToken = default)
    {
        
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var result = _consumer.Consume(cancellationToken);
                var message = System.Text.Json.JsonSerializer.Deserialize<TMessage>(result.Message.Value);
                if (message != null)
                {
                    _logger.LogInformation("Processing message: {Message}", result.Message.Value);
                    await handleMessage(message);
                }
            }
            catch (ConsumeException ex)
            {
                _logger.LogError("Error occured while consuming: {Error}", ex.Message);
            }
        }
    }
}