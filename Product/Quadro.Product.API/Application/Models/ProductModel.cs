namespace Quadro.Product.API.Application.Models;
public record ProductModel(Guid? Id,string Name, string Category, string Description, string CurrencyCode, decimal Price);
