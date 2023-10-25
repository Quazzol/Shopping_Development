using Amazon.SimpleEmail.Model;
using Microsoft.Extensions.Options;

namespace Quadro.Core.Infrastructure.Email;

public class EmailService : IEmailService
{

    private readonly IAmazonSimpleEmailService _amazonEmailService;
    private readonly EmailSettings _emailSettings;
    public EmailService(IAmazonSimpleEmailService amazonEmailService, EmailSettings emailSettings)
    {
        _amazonEmailService = amazonEmailService;
        _emailSettings = emailSettings;
    }


    public async Task<bool> SendEmail(EmailRequest emailRequest)
    {
        var mailBody = new Body(new Content(emailRequest.Body));
        var message = new Message(new Content(emailRequest.Subject), mailBody);
        var destination = new Destination(new List<string> { emailRequest.ToEmail! });
        var request = new SendEmailRequest(_emailSettings.FromEmail, destination, message);
        var response = await _amazonEmailService.SendEmailAsync(request);
        return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
    }
}