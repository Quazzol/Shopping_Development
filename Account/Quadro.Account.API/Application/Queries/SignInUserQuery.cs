namespace Quadro.Account.API.Application.Queries;
public record SignInUserQuery(string Email, string Password) : IQuery<SignInResultModel>;