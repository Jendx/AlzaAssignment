using Confluent.Kafka;
using Domain.Messaging;

namespace Data.Messaging;

public sealed class KafkaQueueProducer<TMessage> : IQueueProducer<TMessage> where TMessage : class
{
    private readonly string _topic;
    private readonly IProducer<Null, string> _producer;
    
    public KafkaQueueProducer(string bootstrapServers, string topic)
    {
        _topic = topic;
        var config = new ProducerConfig { BootstrapServers = bootstrapServers };
        _producer = new ProducerBuilder<Null, string>(config).Build();
    }

    public async Task PublishAsync(TMessage message)
    {
        var value = System.Text.Json.JsonSerializer.Serialize(message);
        await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = value });
    }
}