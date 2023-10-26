using Amazon.SimpleEmail.Model;

namespace Quadro.Core.Infrastructure.Email;

public class EmailService : IEmailService
{

    private readonly IAmazonSimpleEmailService _amazonEmailService;
    private readonly EmailSettings _emailSettings;
    private readonly ILogger<EmailService> _logger;
    public EmailService(IAmazonSimpleEmailService amazonEmailService, EmailSettings emailSettings, ILogger<EmailService> logger)
    {
        _amazonEmailService = amazonEmailService;
        _emailSettings = emailSettings;
        _logger = logger;
    }

    public async Task<SendEmailResult> SendEmailAsync(EmailRequest emailRequest, CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation("Sending e-mail to: {toEmail}", emailRequest.ToEmail);
            var mailBody = new Body(new Content(emailRequest.Body));
            var message = new Message(new Content(emailRequest.Subject), mailBody);
            var destination = new Destination(new List<string> { emailRequest.ToEmail! });
            var request = new SendEmailRequest(_emailSettings.FromEmail, destination, message);
            var response = await _amazonEmailService.SendEmailAsync(request, cancellationToken);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                _logger.LogInformation("E-mail was sent successfully.");

            return new SendEmailResult(response.HttpStatusCode == System.Net.HttpStatusCode.OK, response.MessageId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "E-mail could not be sent.");
        }

        return new SendEmailResult(false, string.Empty);

    }
}