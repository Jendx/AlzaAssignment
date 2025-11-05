namespace Domain.Messaging;

public interface IQueueConsumer<TMessage> where TMessage : class
{
    Task SubscribeAsync(Func<TMessage, Task> handleMessage, CancellationToken cancellationToken = default);
}