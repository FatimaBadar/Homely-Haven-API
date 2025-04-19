using System.Xml.Linq;
using Ecommerce_API.Data;
using Ecommerce_API.DTOs;
using Ecommerce_API.Models;
using Ecommerce_API.View;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Services.Admin
{
    public class UserService : IUserService
    {
        AppDbContext _appDbContext;

        public UserService(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponseVM<List<UserDto>>> GetAllUsers()
        {
            var users = await _appDbContext.Users.ToListAsync();
            if(users == null || users.Count == 0)
            {
                return new ResponseVM<List<UserDto>>("404", "No users found");
            }

            var userListDto = users.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                isAdmin = user.isAdmin
            }).ToList();

            return new ResponseVM<List<UserDto>>("200", "Fetched all users", userListDto);
        }

        public async Task<ResponseVM<UserDto>> GetUserById(int id)
        {
            var user =await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null)
            {
                return new ResponseVM<UserDto>("404", "User not found");
            }
            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                isAdmin = user.isAdmin
            };
            return new ResponseVM<UserDto>("200", "User found", userDto);
        }

        public async Task<ResponseVM<UserDto>> UpdateUser(int id, User newUserDetails)
        {
            var existingUser = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser == null)
            {
                return new ResponseVM<UserDto>("404", "User not found");
            }
            existingUser.Name = newUserDetails.Name;
            existingUser.Email = newUserDetails.Email;
            existingUser.Phone = newUserDetails.Phone;
            existingUser.Address = newUserDetails.Address;
            existingUser.isAdmin = newUserDetails.isAdmin;

            _appDbContext.Users.Update(existingUser);
            await _appDbContext.SaveChangesAsync();

            return new ResponseVM<UserDto>("200", "User updated successfully", new UserDto
            {
                Id = existingUser.Id,
                Name = existingUser.Name,
                Email = existingUser.Email,
                Phone = existingUser.Phone,
                Address = existingUser.Address,
                isAdmin = existingUser.isAdmin
            });
        }

        public async Task<ResponseVM<bool>> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

    }
}
