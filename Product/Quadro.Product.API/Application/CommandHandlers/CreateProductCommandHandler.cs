using Quadro.Product.Domain;

namespace Quadro.Product.API.Application.CommandHandlers;
public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, bool>
{

    private IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.Product
        {
            Id = request.Model.Id ?? Guid.NewGuid(),
            Name = request.Model.Name,
            Category = request.Model.Category,
            Description = request.Model.Description ?? "",
            UnitPrice = Money.Of(request.Model.Price, request.Model.CurrencyCode)
        };


        return await _productRepository.Create(product, cancellationToken);
    }
}