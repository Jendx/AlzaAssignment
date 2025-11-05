using Confluent.Kafka;

namespace Domain.Messaging;

public interface IQueueProducer<TMessage> where TMessage : class
{
    public Task PublishAsync(TMessage message);
}