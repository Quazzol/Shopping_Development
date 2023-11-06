namespace Quadro.Account.API.Application.Commands;
public record SignUpUserCommand(SignUpModel Model) : ICommand<SignUpResultModel>;





