namespace Quadro.Account.API.Application.Commands;
public record SignUpUserCommand(string UserName, string Email, string Password) : ICommand<SignUpResultModel>;





