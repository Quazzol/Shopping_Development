using System.ComponentModel;
using Quadro.Account.Infrastructure.Application;

namespace Quadro.Account.API.Application.Queries;

[DisplayName("SignUpUserRequest")]
public class FindUserQuery : IQuery<UserViewModel>
{

    public string Email { get; set; }   
    
}


public class UserViewModel
{
}
