using Microsoft.AspNetCore.Components;
using Quadro.Account.API.Application.Commands;
using Quadro.Account.Domain;

namespace Quadro.Account.API.Application.CommandHandlers;

public class SignUpUserCommandHandler : ICommandHandler<SignUpUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public SignUpUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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

        return await _userRepository.SignUpUser(user, cancellationToken);
    }
}