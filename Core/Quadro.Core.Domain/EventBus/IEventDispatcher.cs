using MediatR;

namespace Quadro.Core.Domain.EventBus;

public interface IEventDispatcher
{
    Task DispatchAsync(INotification @event, CancellationToken cancellationToken = default);
}