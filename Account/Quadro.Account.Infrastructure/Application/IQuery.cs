using MediatR;

namespace Quadro.Account.Infrastructure.Application;
public interface IQuery<out TQueryResult> : IRequest<TQueryResult>
{

}
