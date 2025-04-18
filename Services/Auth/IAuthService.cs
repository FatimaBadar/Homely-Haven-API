using Ecommerce_API.DTOs;
using Ecommerce_API.Models;
using Ecommerce_API.View;

namespace Ecommerce_API.Services.Auth
{
    public interface IAuthService
    {
        Task<ResponseVM<User>> Register(UserDto userDto);
        Task<ResponseVM<string>> Login(UserDto userDto);
    }
}
