using MediatR;

namespace Quadro.Account.Infrastructure.Application;

public interface ICommandHandler<in TCommand, TCommandResult> : IRequestHandler<TCommand, TCommandResult> where TCommand : ICommand<TCommandResult>
{

}
