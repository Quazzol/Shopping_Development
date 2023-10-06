using Quadro.Core.Domain.SeedWork;

namespace Quadro.Account.Domain
{
    public class UserNameUpdated : IDomainEvent
    {
        public string Name { get; set; }
    }
}
