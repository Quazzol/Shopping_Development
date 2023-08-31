using MediatR;

namespace Quadro.Account.Infrastructure.Application;

public interface IQueryHandler<in TQuery, TQueryResult> : IRequestHandler<TQuery, TQueryResult> where TQuery : IQuery<TQueryResult>
{

}
