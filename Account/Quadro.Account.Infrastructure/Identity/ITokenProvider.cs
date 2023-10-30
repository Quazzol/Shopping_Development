namespace Quadro.Account.Infrastructure.Identity;

public interface ITokenProvider
{
    (string token, DateTime validTo) CreateToken(User user);
}