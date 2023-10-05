using MediatR;

namespace Quadro.Core.Domain.EventBus;
public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : INotification
{ }