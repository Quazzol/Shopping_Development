using Quadro.Product.Domain;

namespace Quadro.Product.API.Application.CommandHandlers;

public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, bool>
{

    private IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        return await _productRepository.Delete(request.Id, cancellationToken);
    }
}