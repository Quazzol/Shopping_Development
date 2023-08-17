
using System.ComponentModel;
using Quadro.Account.Infrastructure;

namespace Quadro.Account.API;

//For Swagger 
[DisplayName("SignUpUserRequest")]
public class SignUpUserCommand : ICommand<int>
{

    public string Name { get; set; }


    public string Email { get; set; }

    public string Password { get; set; }

}

