using MediatR;

namespace Quadro.Account.Infrastructure;
public interface IQuery<out TQueryResult> : IRequest<TQueryResult>
{

}
