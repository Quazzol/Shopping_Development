using MediatR;

namespace Quadro.Account.Infrastructure.Application;

public interface ICommand<out TCommandResult> : IRequest<TCommandResult>
{

}
