namespace Quadro.Core.Domain.CQRS.CommandHandling;


public interface ICommandBus
{
    Task<TResponse> Send<TCommand,TResponse>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : ICommand<TResponse>;
}
