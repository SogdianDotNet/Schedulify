using MassTransit;
using Microsoft.Extensions.Logging;
using Schedulify.Application.Interfaces;

namespace Schedulify.Infrastructure.Queue;

public class QueueClient : IQueueClient
{
    private readonly ILogger<QueueClient> _logger;
    private readonly IPublishEndpoint _publishEndpoint;

    public QueueClient(ILogger<QueueClient> logger, IPublishEndpoint bus)
    {
        _logger = logger;
        _publishEndpoint = bus;
    }

    public async Task SendMessage<T>(T message)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(message);
            
            await _publishEndpoint.Publish(message);

            _logger.LogInformation($"Message '{message.GetType().Name}' sent to the queue.");
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"An error has occured while attempting to send a message ('{message.GetType().Name}') to the queue.");

            throw;
        }
    }
}