using Ardalis.GuardClauses;
using Quadro.Core.Domain.SeedWork;

namespace Quadro.Account.Domain;

public class Credentials : ValueObject<Credentials>
{
    public EmailAddress Address { get; }
    public string Password { get; }

    public Credentials(EmailAddress address, string password)
    {
        Guard.Against.Null(address, nameof(address));
        Guard.Against.NullOrEmpty(password, nameof(password));
        Address = address;
        Password = password;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address;
        yield return Password;
    }
}