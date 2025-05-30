using System.Text.Json.Serialization;

namespace UserService.Models
{
    public class LoginDTO
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
