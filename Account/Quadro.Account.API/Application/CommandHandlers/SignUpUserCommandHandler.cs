using Quadro.Account.Infrastructure;

namespace Quadro.Account.API;
public class SignUpUserCommandHandler : ICommandHandler<SignUpUserCommand, int>
{
    public Task<int> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
    {

        //Implement Use Case
        return Task.FromResult(0);
    }
}
