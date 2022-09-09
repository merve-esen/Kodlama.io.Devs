namespace Application.Features.Auth.Models
{
    public class RegisterModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
