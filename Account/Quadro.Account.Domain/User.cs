using Ardalis.GuardClauses;
using Quadro.Account.Domain.Common;

namespace Quadro.Account.Domain;

public class User : Entity<Guid>
{
    public User(Credentials credentials, Guid? userId = null)
    {
        Guard.Against.Null(credentials, nameof(credentials));
        Credentials = credentials;
        Id = userId ?? Guid.NewGuid();
    }

    public Credentials Credentials { get; }

    public string Name { get; private set; }

    public void UpdateName(string name)
    {
        if (name == null)
        {
            return;
        }
        Name = name;
        DomainEvents.Add(new UserNameUpdated {Name = Name});

    }

}
