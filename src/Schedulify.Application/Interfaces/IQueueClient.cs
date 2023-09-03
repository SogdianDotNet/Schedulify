namespace Schedulify.Application.Interfaces;

public interface IQueueClient
{
    Task SendMessage<T>(T message);
}