namespace Quadro.Account.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AccountDbContext _accountDbContext;

        public UserRepository(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }
        public Task SignInUser(User user, CancellationToken cancellationToken = default)
                    => _accountDbContext.SignInUser(user, cancellationToken);

        public Task<Guid> SignUpUser(User user, CancellationToken cancellationToken = default)
                    => _accountDbContext.SignUpUser(user, cancellationToken);


    }
}
