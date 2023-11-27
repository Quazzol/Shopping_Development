namespace Quadro.Product.Infrastructure.Repositories;

using Quadro.Product.Domain;
public class ProductRepository : IProductRepository
{

    private ProductDbContext _productDbContext;
    public ProductRepository(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }

    public Task<bool> Create(Product product, CancellationToken cancellationToken = default)
                 => _productDbContext.Create(product, cancellationToken);
    public Task<bool> Update(Product product, CancellationToken cancellationToken = default)
                => _productDbContext.Update(product, cancellationToken);
    public Task<bool> Delete(Guid Id, CancellationToken cancellationToken = default)
                => _productDbContext.Delete(Id, cancellationToken);

    public Task<Product> GetById(Guid Id, CancellationToken cancellationToken = default)
                => _productDbContext.GetById(Id, cancellationToken);

    public Task<List<Product>> ListAll(CancellationToken cancellationToken = default)
               => _productDbContext.ListAll(cancellationToken);
}
