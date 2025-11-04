using Confluent.Kafka;
using DotNetEnv;

namespace KafkaJob.Services;

public sealed class ConsumerQueueService
{
    public ConsumerQueueService()
    {
        Env.TraversePath().Load();
        var port = Environment.GetEnvironmentVariable("KAFKA_PORT");
        ArgumentException.ThrowIfNullOrWhiteSpace(port);
        
        var host = Environment.GetEnvironmentVariable("KAFKA_HOST");
        ArgumentException.ThrowIfNullOrWhiteSpace(host);

        var config = new ConsumerConfig
        {
            BootstrapServers = $"{host}:{port}",
            GroupId = "kafka-job",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
    }
}