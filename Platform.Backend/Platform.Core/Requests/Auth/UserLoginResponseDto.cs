namespace Platform.Core.Requests.Auth
{
    public class UserLoginResponseDto
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
