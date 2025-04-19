using Ecommerce_API.DTOs;
using Ecommerce_API.Models;
using Ecommerce_API.View;

namespace Ecommerce_API.Services.Auth
{
    public interface IAuthService
    {
        Task<ResponseVM<RegisteredUserDto>> Register(UserRegisterDto userDto);
        Task<ResponseVM<AuthDto>> Login(UserLoginDto userDto);
        Task<ResponseVM<AuthDto>> GetRefreshToken(RefreshTokenDto userDto);
    }
}
