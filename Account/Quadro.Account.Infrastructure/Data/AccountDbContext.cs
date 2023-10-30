using System.Security.Authentication;
using Amazon.SimpleEmail.Model;

namespace Quadro.Account.Infrastructure;

public class AccountDbContext
{

    private readonly IAmazonDynamoDB _amazonDynamoDB;
    public AccountDbContext(IAmazonDynamoDB amazonDynamoDB)
    {
        _amazonDynamoDB = amazonDynamoDB;
    }

    public async Task<User> AuthenticateUser(string email, string password, CancellationToken cancellationToken = default)
    {
        var userItem = await GetUserByCredentials(email, password, cancellationToken);
        if (!userItem.Any())
        {
            throw new AuthenticationException("Email or Password is invalid!");
        }
        var json = Document.FromAttributeMap(userItem).ToJson();
        var userData = JsonSerializer.Deserialize<UserData>(json);
        return new User
        {
            Id = Guid.Parse(userData.Id),
            Credentials = new Credentials(EmailAddress.From(userData.Email), userData.Password),
            UserName = userData.UserName

        };

    }

    public async Task<Guid> RegisterUser(User user, CancellationToken cancellationToken = default)
    {
        var userItem = await GetUserByCredentials(user.Credentials.Address.ToString(), user.Credentials.Password, cancellationToken);
        if (userItem != null)
        {
            throw new AlreadyExistsException("User Credentials already exist");
        }

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

    private async Task<Dictionary<string, AttributeValue>> GetUserByCredentials(string email, string password, CancellationToken cancellationToken = default)
    {
        var request = new ScanRequest
        {
            TableName = "users",
            ExpressionAttributeNames = new Dictionary<string, string>
                {
                 { "#email", "email" },
                 { "#password", "password" },
                },
            ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                {
                 { ":email", new AttributeValue { S = email }},
                 { ":password", new AttributeValue { S = password } }
                 },

            FilterExpression = "#email = :email and #password = :password"
        };

        var response = await _amazonDynamoDB.ScanAsync(request);
        return response.Items.FirstOrDefault();
    }

}




