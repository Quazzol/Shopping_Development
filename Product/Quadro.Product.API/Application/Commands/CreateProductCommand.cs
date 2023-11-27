namespace Quadro.Product.API.Application.Commands;

public record CreateProductCommand(ProductModel Model) : ICommand<bool>;