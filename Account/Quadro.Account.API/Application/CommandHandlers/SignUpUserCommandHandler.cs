

using Quadro.Account.Domain.Events;
using Quadro.Core.Domain.EventBus;

namespace Quadro.Account.API.Application.CommandHandlers;

public class SignUpUserCommandHandler : ICommandHandler<SignUpUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IEventDispatcher _eventDispatcher;


    public SignUpUserCommandHandler(IUserRepository userRepository, IEventDispatcher eventDispatcher)
    {
        _userRepository = userRepository;
        _eventDispatcher = eventDispatcher;
    }
    public async Task<Guid> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
    {
        var mailAddress = EmailAddress.From(request.Email);
        var credentials = new Credentials(mailAddress, request.Password);
        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = request.UserName,
            Credentials = credentials
        };

        /*   var validator = new UserNameMustBeUpperCaseValidator();
          var result = validator.Validate(user);
          if (!result.IsValid)
          {
              throw new InvalidOperationException(result.Errors.ToString());
          } */

        var result = await _userRepository.SignUpUser(user, cancellationToken);

        if (result != Guid.Empty)
        {
            await _eventDispatcher.DispatchAsync(@event: new UserRegistered(user.Id, user.UserName, user.Credentials.Address.ToString()), cancellationToken);
        }

        return result;


    }
}