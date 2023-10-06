using System.Net.Mail;
using Quadro.Core.Domain.SeedWork;

namespace Quadro.Account.Domain;

public class EmailAddress : ValueObject<EmailAddress>
{
    private readonly string _address;

    private EmailAddress(string address)
    {
        _address = address;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _address;
    }

    public override string ToString()
    {
        return _address;
    }

    public static EmailAddress From(string address)
    {
        var emailAddress = new EmailAddress(address);
        //Validation
        if (MailAddress.TryCreate(emailAddress.ToString(), out var mailAddress))
        {
            throw new FormatException("Invalid Mail Address");
        }
        return emailAddress;
    }
}