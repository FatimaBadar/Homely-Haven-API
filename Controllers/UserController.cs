using Ecommerce_API.DTOs;
using Ecommerce_API.Models;
using Ecommerce_API.Services.Admin;
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
        public async Task<ActionResult<ResponseVM<List<User>>>> GetAllUsers()
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
        [HttpGet("getUserById")]
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


    }
}
