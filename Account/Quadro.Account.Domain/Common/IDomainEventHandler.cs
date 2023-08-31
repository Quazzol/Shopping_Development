namespace Quadro.Account.Domain.Common;

public interface IDomainEventHandler<in TDomainEvent> where TDomainEvent : IDomainEvent
{
    public void Handle(TDomainEvent domainEvent);
}

public interface IDomainEventHandler
{
}