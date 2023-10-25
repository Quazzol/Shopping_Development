using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.SimpleEmail;
using Quadro.Core.Infrastructure.AWS;

namespace Quadro.Core.Infrastructure.UnitTests;

public class EmailServiceTest
{
    [Fact]
    public async void SendEmail_ShouldBeTrue_WhenToEmailIsValid()
    {
        var toEmail = "yasino@nebim.com.tr";
        var subject = "Test";
        var body = "Welcome to Shopping App :)";

        var settings = new Email.EmailSettings
        {
            FromEmail = "quadroshoppingproject@gmail.com"
        };

        var awsCredentials = QuadroAWSCredentials.GetAWSCredentials();
        var emailServiceClient = new AmazonSimpleEmailServiceClient(awsCredentials, RegionEndpoint.USEast1);
        var emailService = new Email.EmailService(emailServiceClient, settings);
        var result = await emailService.SendEmail(new Email.EmailRequest(toEmail, subject, body));
        Assert.True(result);
    }





}