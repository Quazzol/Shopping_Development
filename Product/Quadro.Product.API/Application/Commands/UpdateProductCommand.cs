namespace Quadro.Product.API.Application.Commands;

public record UpdateProductCommand(ProductModel Model) : ICommand<bool>;
