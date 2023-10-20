namespace Quadro.Core.Domain.CQRS.QueryHandling;

public interface IQuery<out TResponse> : IRequest<TResponse>
{

}
