
using Quadro.Product.Domain;

namespace Quadro.Product.API.Application.QueryHandlers;

public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductModel>
{

    private IProductRepository _productRepository;

    public GetProductQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetById(request.Id, cancellationToken);

        return new ProductModel(product.Id, product.Name, product.Category, product.Description ?? "", product.UnitPrice!.Currency.Symbol, product.UnitPrice.Amount);
    }
}