namespace Quadro.Account.Domain.Common
{
    public interface IDomainEventDispatcher
    {
        public void Dispatch<T>(T events);
    }
}
