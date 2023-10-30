namespace Quadro.Account.Domain;

public interface IUserRepository
{
   Task<Guid> RegisterUser(User user, CancellationToken cancellationToken = default);
   Task<User> AuthenticateUser(string email, string password, CancellationToken cancellationToken = default);
}
