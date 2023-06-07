namespace TwitchKeyAPI.Models
{
    public class AddTwitchKeyRequest
    {
        public string AccessToken { get; set; }
        public string ExpiresIn { get; set; }
        public string TokenType { get; set; }
    }
}
