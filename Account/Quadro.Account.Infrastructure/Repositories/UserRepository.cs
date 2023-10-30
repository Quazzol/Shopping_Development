namespace Quadro.Account.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AccountDbContext _accountDbContext;

        public UserRepository(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        public Task<User> AuthenticateUser(string email, string password, CancellationToken cancellationToken = default)
         => _accountDbContext.AuthenticateUser(email, password, cancellationToken);



        public Task<Guid> RegisterUser(User user, CancellationToken cancellationToken = default)
                    => _accountDbContext.RegisterUser(user, cancellationToken);


    }
}
