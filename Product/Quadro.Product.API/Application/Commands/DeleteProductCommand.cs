namespace Quadro.Product.API.Application.Commands;

public record DeleteProductCommand(Guid Id) : ICommand<bool>;