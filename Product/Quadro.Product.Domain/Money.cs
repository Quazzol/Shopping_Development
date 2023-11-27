
namespace Quadro.Product.Domain;

public class Money : ValueObject<Money>
{
    private Money(decimal value, string currencyCode)
    {
        Amount = Guard.Against.Negative(value, nameof(value), message: "Amount cannot be negative.");
        Currency = Currency.Of(currencyCode);
    }
    public decimal Amount { get; }
    public Currency Currency { get; }

    public static Money Of(decimal value, string currencyCode) => new Money(value, currencyCode);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}