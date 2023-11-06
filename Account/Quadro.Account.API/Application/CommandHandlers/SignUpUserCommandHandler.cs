

namespace Quadro.Account.API.Application.CommandHandlers;

public class SignUpUserCommandHandler : ICommandHandler<SignUpUserCommand, SignUpResultModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly IEncryptionService _encryptionService;
    private readonly IValidator<SignUpModel> _signupValidator;


    public SignUpUserCommandHandler(IUserRepository userRepository, IEventDispatcher eventDispatcher, IEncryptionService encryptionService, IValidator<SignUpModel> signupValidator)
    {
        _userRepository = userRepository;
        _eventDispatcher = eventDispatcher;
        _encryptionService = encryptionService;
        _signupValidator = signupValidator;
    }

    public async Task<SignUpResultModel> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
    {

        _signupValidator.ValidateAndThrow(request.Model);

        var mailAddress = EmailAddress.From(request.Model.Email);
        var credentials = new Credentials(mailAddress, _encryptionService.Encrypt(request.Model.Password));
        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = request.Model.UserName,
            Credentials = credentials
        };

        /*   var validator = new UserNameMustBeUpperCaseValidator();
          var result = validator.Validate(user);
          if (!result.IsValid)
          {
              throw new InvalidOperationException(result.Errors.ToString());
          } */

        var result = await _userRepository.RegisterUser(user, cancellationToken);

        if (result != Guid.Empty)
        {
            await _eventDispatcher.DispatchAsync(@event: new UserRegistered(user.Id, user.UserName, user.Credentials.Address.ToString()), cancellationToken);
        }

        return new SignUpResultModel(result);


    }
}