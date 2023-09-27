namespace Quadro.Account.Domain.Common
{
    public abstract class Entity<TId>
    {
        protected List<IDomainEvent> DomainEvents { get; private set; }

        public TId Id { get; protected set; }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            DomainEvents ??= new List<IDomainEvent>();
            DomainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            DomainEvents?.Remove(domainEvent);
        }

    }
}
