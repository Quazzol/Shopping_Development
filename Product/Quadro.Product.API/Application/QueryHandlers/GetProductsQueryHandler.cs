
using Quadro.Product.Domain;

namespace Quadro.Product.API.Application.QueryHandlers;

public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, IEnumerable<ProductModel>>
{

    private IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var list = await _productRepository.ListAll(cancellationToken);
        return list.Select(p => new ProductModel(p.Id, p.Name, p.Category, p.Description ?? "", p.UnitPrice!.Currency.Symbol, p.UnitPrice.Amount));
    }
}