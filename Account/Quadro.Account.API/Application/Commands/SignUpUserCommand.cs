using System.ComponentModel;
using Quadro.Account.Infrastructure.Application;

namespace Quadro.Account.API.Application.Commands;

//For Swagger 
[DisplayName("SignUpUserRequest")]
public class SignUpUserCommand : ICommand<Guid>
{

    public  string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

}

