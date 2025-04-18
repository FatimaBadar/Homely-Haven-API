using Ecommerce_API.DTOs;
using Ecommerce_API.Models;
using Ecommerce_API.View;

namespace Ecommerce_API.Services.Auth
{
    public class AuthService : IAuthService
    {
        public Task<ResponseVM<string>> Login(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseVM<User>> Register(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
