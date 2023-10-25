namespace Quadro.Account.Domain.Commands;

//For Swagger 
[DisplayName("SignUpUserRequest")]
public record SignUpUserCommand(string UserName, string Email, string Password) : ICommand<Guid>;



