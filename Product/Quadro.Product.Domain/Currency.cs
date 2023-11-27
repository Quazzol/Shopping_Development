namespace Quadro.Product.Domain;
public class Currency : ValueObject<Currency>
{
    private Currency(string code, string symbol)
    {
        Code = Guard.Against.NullOrEmpty(code, nameof(Code));
        Symbol = Guard.Against.NullOrEmpty(symbol, nameof(Symbol));
    }


    public string Code { get; }
    public string Symbol { get; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
        yield return Symbol;
    }

    public static Currency Of(string currencyCode) => new Currency(currencyCode, GetSymbol(currencyCode));

    private static string GetSymbol(string currencyCode)
    {
        return currencyCode switch
        {
            "TRY" => "TRY",
            "USD" => "$",
            "EUR" => "£",
            _ => throw new ArgumentException($"Invalid currency code {currencyCode}")
        };
    }
}



