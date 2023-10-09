using Amazon.DynamoDBv2;

namespace Quadro.Account.Infrastructure
{
    public class AccountDbContext : DynamoDBContext
    {
        public AccountDbContext(IAmazonDynamoDB client) : base(client)
        {
        }

        public Task SignInUser(User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> SignUpUser(User user, CancellationToken cancellationToken = default)
        {
            var userData = new UserData
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Credentials.Address.ToString(),
                Password = user.Credentials.Password
            };

            await SaveAsync(userData, cancellationToken);

            return user.Id;

        }
       
    }
}
