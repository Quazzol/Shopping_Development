namespace Quadro.Account.API.Application.QueryHandlers;

public class SignInUserQueryHandler : IQueryHandler<SignInUserQuery, SignInResultModel>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenProvider _tokenProvider;
    private readonly IEncryptionService _encryptionService;
    public SignInUserQueryHandler(IUserRepository userRepository, ITokenProvider tokenProvider, IEncryptionService encryptionService)
    {
        _userRepository = userRepository;
        _tokenProvider = tokenProvider;
        _encryptionService = encryptionService;

    }

    public async Task<SignInResultModel> Handle(SignInUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.AuthenticateUser(request.Model.Email, _encryptionService.Encrypt(request.Model.Password), cancellationToken);
        var token = _tokenProvider.CreateToken(user);

        return new SignInResultModel(token.token, token.validTo);
    }
}
