namespace Quadro.Account.Infrastructure.Data
{
    [DynamoDBTable("User")]
    public class UserData
    {
        [DynamoDBHashKey]
        public Guid Id { get; set; }

        [DynamoDBProperty]
        public string UserName { get; set; }

        [DynamoDBProperty]
        public string Email { get; set; }

        [DynamoDBProperty]
        public string Password { get; set; }
    }
}
