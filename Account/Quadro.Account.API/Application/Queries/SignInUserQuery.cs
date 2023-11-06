namespace Quadro.Account.API.Application.Queries;
public record SignInUserQuery(SignInModel Model) : IQuery<SignInResultModel>;