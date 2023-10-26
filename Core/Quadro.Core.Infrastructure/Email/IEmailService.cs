namespace Quadro.Core.Infrastructure.Email;

public interface IEmailService
{
    Task<SendEmailResult> SendEmailAsync(EmailRequest emailRequest, CancellationToken cancellationToken = default);
}