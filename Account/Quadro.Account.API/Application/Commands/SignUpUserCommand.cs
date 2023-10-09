using System.ComponentModel;

namespace Quadro.Account.API.Application.Commands;

//For Swagger 
[DisplayName("SignUpUserRequest")]
public record SignUpUserCommand(string UserName, string Email, string Password) : ICommand<Guid>;



