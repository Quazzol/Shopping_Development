namespace Quadro.Account.Domain.Common
{
    public abstract class Entity<TId>
    {

        private List<IDomainEvent> _domainEvents;
        public List<IDomainEvent> DomainEvents => _domainEvents;

        public TId Id { get; protected set; }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents?.Remove(domainEvent);
        }

    }
}
