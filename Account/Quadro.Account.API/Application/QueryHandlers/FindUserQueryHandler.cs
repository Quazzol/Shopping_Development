using Quadro.Account.API.Application.Queries;

namespace Quadro.Account.API.Application.QueryHandlers;

public class FindUserQueryHandler : IQueryHandler<FindUserQuery, UserViewModel>
{
    public FindUserQueryHandler()
    {
            
    }
    public Task<UserViewModel> Handle(FindUserQuery request, CancellationToken cancellationToken)
    {
        //Implement Use Case
        return Task.FromResult(new UserViewModel());
    }
}
