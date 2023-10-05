using Quadro.Core.Domain.EventBus;

namespace Quadro.Core.Infrastructure.EventBus;

public class EventDispatcher : IEventDispatcher
{

    private readonly IServiceScopeFactory _serviceScopeFactory;
    public EventDispatcher(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task DispatchAsync(INotification @event, CancellationToken cancellationToken = default)
    {
        var mediator = _serviceScopeFactory.
                        CreateScope().
                        ServiceProvider.
                        GetRequiredService<IMediator>();

        await mediator.Publish(@event, cancellationToken);
    }
}