namespace Ecommerce_API.DTOs
{
    public class UserRegisterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

    }

    public class RegisteredUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
    }

    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
