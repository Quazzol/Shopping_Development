namespace Quadro.Product.Domain;

public interface IProductRepository
{
    Task<bool> Create(Product product, CancellationToken cancellationToken = default);
    Task<bool> Update(Product product, CancellationToken cancellationToken = default);
    Task<bool> Delete(Guid Id, CancellationToken cancellationToken = default);
    Task<Product> GetById(Guid Id, CancellationToken cancellationToken = default);
    Task<List<Product>> ListAll(CancellationToken cancellationToken = default);

}