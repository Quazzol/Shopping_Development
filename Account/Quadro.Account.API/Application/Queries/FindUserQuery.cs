using System.ComponentModel;
using Quadro.Account.Infrastructure;

namespace Quadro.Account.API;

[DisplayName("SignUpUserRequest")]
public class FindUserQuery : IQuery<UserViewModel>
{

    public string Email { get; set; }   
    
}


public class UserViewModel
{
}
