
namespace Quadro.Account.Infrastructure
{
    public class AccountDbContext
    {

        private readonly IAmazonDynamoDB _amazonDynamoDB;
        public AccountDbContext(IAmazonDynamoDB amazonDynamoDB)
        {
            _amazonDynamoDB = amazonDynamoDB;
        }

        public Task SignInUser(User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> SignUpUser(User user, CancellationToken cancellationToken = default)
        {

            var userData = new UserData
            {
                Id = user.Id.ToString(),
                UserName = user.UserName,
                Email = user.Credentials.Address.ToString(),
                Password = user.Credentials.Password
            };

            var json = JsonSerializer.Serialize(userData);
            var itemAsDocument = Document.FromJson(json);
            var itemAsAttributes = itemAsDocument.ToAttributeMap();

            var request = new PutItemRequest
            {
                TableName = "users",
                Item = itemAsAttributes
            };

            var response = await _amazonDynamoDB.PutItemAsync(request, cancellationToken);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                return user.Id;

            return Guid.Empty;
        }

    }
}
