namespace Ecommerce_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public required bool isAdmin { get; set; }
        public List<Order>? Orders { get; set; } 

    }
}
