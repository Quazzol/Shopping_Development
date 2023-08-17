using Quadro.Account.Infrastructure;

namespace Quadro.Account.API;
public class FindUserQueryHandler : IQueryHandler<FindUserQuery, UserViewModel>
{
    public Task<UserViewModel> Handle(FindUserQuery request, CancellationToken cancellationToken)
    {
        //Implement Use Case
        return Task.FromResult(new UserViewModel());
    }
}
