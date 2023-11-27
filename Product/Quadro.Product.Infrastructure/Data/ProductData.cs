namespace Quadro.Product.Infrastructure.Data;
public class ProductData
{

    [JsonPropertyName("pk")]
    public string Pk => Id;

    [JsonPropertyName("sk")]
    public string Sk => Pk;

    [JsonPropertyName("id")]
    public string Id { get; init; } = default!;

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("currencyCode")]
    public required string CurrencyCode { get; set; }
}