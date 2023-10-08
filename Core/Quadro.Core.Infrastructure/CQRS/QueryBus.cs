using Quadro.Core.Domain.CQRS.QueryHandling;

namespace Quadro.Core.Infrastructure.CQRS;

public class QueryBus : IQueryBus
{

    private readonly IMediator _mediator;
    private readonly ILogger<QueryBus> _logger;

    public QueryBus(IMediator mediator, ILogger<QueryBus> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    public Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Executing query: {query}", query);
        return _mediator.Send(query);
    }
}