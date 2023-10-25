namespace Quadro.Core.Infrastructure.Email;

public interface IEmailService
{
    Task<bool> SendEmail(EmailRequest emailRequest);
}