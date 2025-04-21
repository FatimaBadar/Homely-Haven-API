using Ecommerce_API.DTOs;
using Ecommerce_API.Models;
using Ecommerce_API.Services.Users;
using Ecommerce_API.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("getAllUsers")]
        public async Task<ActionResult<ResponseVM<IEnumerable<UserDto>>>> GetAllUsers()
        {
            try
            {
                var data = await _userService.GetAllUsers();
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("getUserById/{id}")]
        public async Task<ActionResult<ResponseVM<UserDto>>> GetUserById(int id)
        {
            try
            {
                var data = await _userService.GetUserById(id);
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("updateUser/{id}")]
        public async Task<ActionResult<ResponseVM<UserDto>>> UpdateUser(int id, User newUserDetails)
        {
            try
            {
                var data = await _userService.UpdateUser(id, newUserDetails);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("deleteUser/{id}")]
        public async Task<ActionResult<ResponseVM<bool>>> DeleteUser(int id)
        {
            try
            {
                var data = await _userService.DeleteUser(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
