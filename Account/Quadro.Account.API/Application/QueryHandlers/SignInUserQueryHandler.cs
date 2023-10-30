namespace Quadro.Account.API.Application.QueryHandlers;

public class SignInUserQueryHandler : IQueryHandler<SignInUserQuery, SignInResultModel>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenProvider _tokenProvider;
    public SignInUserQueryHandler(IUserRepository userRepository, ITokenProvider tokenProvider)
    {
        _userRepository = userRepository;
        _tokenProvider = tokenProvider;

    }

    public async Task<SignInResultModel> Handle(SignInUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.AuthenticateUser(request.Email, request.Password, cancellationToken);
        var token = _tokenProvider.CreateToken(user);

        return new SignInResultModel(token.token, token.validTo);
    }
}
