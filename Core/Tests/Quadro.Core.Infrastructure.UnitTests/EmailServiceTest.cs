using Amazon;
using Amazon.SimpleEmail;
using Quadro.Core.Infrastructure.AWS;
using Quadro.Core.Infrastructure.Email;

namespace Quadro.Core.Infrastructure.UnitTests;

public class EmailServiceTest
{

    [Theory]
    [InlineData("yasino@nebim.com.tr")]
    [InlineData("yasino11@nebim.com.tr")]
    public async void SendEmail_ShouldBeTrue_WhenToEmailIsValid(string toEmail)
    {
        var subject = "Test";
        var body = "Welcome to Shopping App :)";

        var settings = new Email.EmailSettings
        {
            FromEmail = "quadroshoppingproject@gmail.com"
        };

        ILogger<EmailService> logger = NullLoggerFactory.Instance.CreateLogger<EmailService>();
        var awsCredentials = QuadroAWSCredentials.GetAWSCredentials();
        var emailServiceClient = new AmazonSimpleEmailServiceClient(awsCredentials, RegionEndpoint.USEast1);
        var emailService = new EmailService(emailServiceClient, settings, logger);
        var result = await emailService.SendEmailAsync(new Email.EmailRequest(toEmail, subject, body));
        Assert.True(result.IsSuccesful);
    }
}