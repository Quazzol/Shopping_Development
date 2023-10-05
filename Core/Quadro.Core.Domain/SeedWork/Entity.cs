namespace Quadro.Core.Domain.SeedWork;
public abstract class Entity<TId> : IEntity<TId>
{
    public required TId Id { get; init; }

    protected List<IDomainEvent>? DomainEvents { get; private set; }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        DomainEvents ??= new List<IDomainEvent>();
        DomainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(IDomainEvent domainEvent)
    {
        DomainEvents?.Remove(domainEvent);
    }

    public virtual object Clone() => MemberwiseClone();
}
