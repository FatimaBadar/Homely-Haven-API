using System.Text.Json.Serialization;

namespace Ecommerce_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public required bool isAdmin { get; set; } = false;

        //[JsonIgnore]
        public ICollection<Order>? Orders { get; set; } //navigation property

    }
}
