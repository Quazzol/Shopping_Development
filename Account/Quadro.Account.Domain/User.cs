using Ardalis.GuardClauses;
using Quadro.Core.Domain.SeedWork;

namespace Quadro.Account.Domain;

public class User : Entity<Guid>
{
    public required Credentials Credentials { get; init; }
    public required string UserName { get; init; }
}
