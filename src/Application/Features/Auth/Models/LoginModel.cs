namespace Application.Features.Auth.Models
{
    public class LoginModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
