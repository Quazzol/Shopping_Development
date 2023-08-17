using MediatR;

namespace Quadro.Account.Infrastructure;
public interface ICommand<out TCommandResult> : IRequest<TCommandResult>
{

}
