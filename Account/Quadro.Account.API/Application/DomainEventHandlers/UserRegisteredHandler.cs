using Quadro.Core.Infrastructure.Email;

namespace Quadro.Account.API.Application.EventHandlers;

public class UserRegisteredHandler : IEventHandler<UserRegistered>
{

    private readonly IEmailService _emailService;
    public UserRegisteredHandler(IEmailService emailService)
    {
        _emailService = emailService;
    }
    public Task Handle(UserRegistered notification, CancellationToken cancellationToken)
    {
        var emailRequest = new EmailRequest(ToEmail: notification.Email, "Information", "Welcome to Shopping App :)");
        return _emailService.SendEmailAsync(emailRequest);
    }
}