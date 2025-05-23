﻿using Ecommerce_API.DTOs;
using Ecommerce_API.Models;
using Ecommerce_API.View;

namespace Ecommerce_API.Services.Users
{
    public interface IUserService
    {
        Task<ResponseVM<IEnumerable<UserDto>>> GetAllUsers();
        Task<ResponseVM<UserDto>> GetUserById(int id);
        Task<ResponseVM<UserDto>> UpdateUser(int id, User newUserDetails);
        Task<ResponseVM<bool>> DeleteUser(int id);
    }
}
