using System.ComponentModel;

namespace Quadro.Account.API.Application.Queries;

[DisplayName("SignUpUserRequest")]
public class FindUserQuery : IQuery<UserViewModel>
{

    public string Email { get; set; }   
    
}


public class UserViewModel
{
}
