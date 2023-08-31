using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Quadro.Account.Domain.Common;

namespace Quadro.Account.Domain;

public class Credentials : ValueObject
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