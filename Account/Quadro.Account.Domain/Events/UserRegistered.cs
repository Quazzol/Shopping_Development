using Quadro.Core.Domain.SeedWork;

namespace Quadro.Account.Domain.Events;
public record UserRegistered(Guid Id, string UserName, string Email) : IDomainEvent
{
}