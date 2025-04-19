namespace Ecommerce_API.DTOs
{
    public class AuthDto
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }

    public class RefreshTokenDto
    {
        public required int UserId { get; set; }
        public required string RefreshToken { get; set; }
    }
}
