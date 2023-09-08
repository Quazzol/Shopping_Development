using Microsoft.AspNetCore.Components;
using Quadro.Account.API.Application.Commands;
using Quadro.Account.Domain;
using Quadro.Account.Domain.Common;
using Quadro.Account.Infrastructure.Application;

namespace Quadro.Account.API.Application.CommandHandlers;

public class SignUpUserCommandHandler : ICommandHandler<SignUpUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IDomainEventDispatcher _dispatcher;

    public SignUpUserCommandHandler(IUserRepository userRepository, IDomainEventDispatcher dispatcher)
    {
        _userRepository = userRepository;
        _dispatcher = dispatcher;
    }
    public Task<Guid> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
    {
        var mailAddress = EmailAddress.From(request.Email);
        var credentials = new Credentials(mailAddress, request.Password);
        var user = new User(credentials);

        var validator = new UserNameMustBeUpperCaseValidator();
        var result = validator.Validate(user);
        if (!result.IsValid)
        {
            throw new InvalidOperationException(result.Errors.ToString());
        }
        user.UpdateName(request.Name);
        foreach (var domainEvent in user.DomainEvents)
        {
            _dispatcher.Dispatch(domainEvent);
        }

        return _userRepository.Save(user);
    }
}
