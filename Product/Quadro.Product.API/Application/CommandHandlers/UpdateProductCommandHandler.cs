using Quadro.Product.Domain;

namespace Quadro.Product.API.Application.CommandHandlers;
public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, bool>
{

    private IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {

        var product = new Domain.Product
        {
            Id = (Guid)request.Model.Id!,
            Name = request.Model.Name,
            Category = request.Model.Category,
            Description = request.Model.Description ?? "",
            UnitPrice = Money.Of(request.Model.Price, request.Model.CurrencyCode)
        };


        return await _productRepository.Update(product, cancellationToken);
    }
}