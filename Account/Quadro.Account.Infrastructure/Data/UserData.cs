using System.Text.Json.Serialization;

namespace Quadro.Account.Infrastructure.Data
{
    public class UserData
    {

        [JsonPropertyName("pk")]
        public string Pk => Id.ToString();

        [JsonPropertyName("sk")]
        public string Sk => Pk;

        [JsonPropertyName("id")]
        public string Id { get; init; } = default!;

        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
