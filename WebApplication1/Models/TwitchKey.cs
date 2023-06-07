namespace TwitchKeyAPI.Models
{
    public class TwitchKey
    {

        public Guid Id { get; set; }
        public string AccessToken { get; set; }
        public string ExpiresIn { get; set; }
        public string TokenType { get; set; }
    }
}
