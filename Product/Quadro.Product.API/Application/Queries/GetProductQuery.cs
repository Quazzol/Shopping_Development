namespace Quadro.Product.API.Application.Queries;

public record GetProductQuery(Guid Id) : IQuery<ProductModel>;
