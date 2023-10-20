namespace Quadro.Core.Domain.CQRS.CommandHandling;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
