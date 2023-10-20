using Quadro.Core.Domain.EventBus;

namespace Quadro.Core.Infrastructure.EventBus;

public class EventDispatcher : IEventDispatcher
{

    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<EventDispatcher> _logger;
    public EventDispatcher(IServiceScopeFactory serviceScopeFactory, ILogger<EventDispatcher> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
    }

    public async Task DispatchAsync(INotification @event, CancellationToken cancellationToken = default)
    {

        _logger.LogInformation("Publishing event {@event}", @event);

        var mediator = _serviceScopeFactory.
                        CreateScope().
                        ServiceProvider.
                        GetRequiredService<IMediator>();

        await mediator.Publish(@event, cancellationToken);
    }
}