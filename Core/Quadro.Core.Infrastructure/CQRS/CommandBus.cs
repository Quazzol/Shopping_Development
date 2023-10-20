
namespace Quadro.Core.Infrastructure.CQRS;
public class CommandBus : ICommandBus
{

    private readonly IMediator _mediator;
    private readonly ILogger<CommandBus> _logger;

    public CommandBus(IMediator mediator, ILogger<CommandBus> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    public Task<TResponse> Send<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand<TResponse>
    {
        _logger.LogInformation("Sending command: {command}", command);
        return _mediator.Send(command, cancellationToken);
    }
}
