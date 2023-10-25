namespace Quadro.Core.Infrastructure.Email;

public record EmailRequest(string ToEmail, string Subject, string Body)
{ }