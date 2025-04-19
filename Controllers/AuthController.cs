using Azure;
using Ecommerce_API.DTOs;
using Ecommerce_API.Models;
using Ecommerce_API.Services.Auth;
using Ecommerce_API.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        //private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            //_logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ResponseVM<RegisteredUserDto>>> Register(UserRegisterDto userData)
        {
            try
            {
                var data = await _authService.Register(userData);
                //_logger.LogInformation($"Response Code: {data.StatusCode}\nResponse Message: {data.Message}; \n Response Data: {data.ResponseData}");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("Couldn't register the user");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseVM<AuthDto>>> Login(UserLoginDto userData)
        {
            try
            {
                var data = await _authService.Login(userData);
                //_logger.LogInformation($"Response Code: {data.StatusCode}\nResponse Message: {data.Message}; \n Response Data: {data.ResponseData}");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid username or password");
            }
        }

        [HttpPost("refreshToken")]
        public async Task<ActionResult<ResponseVM<AuthDto>>> RefreshToken(RefreshTokenDto refreshTokenDto)
        {
            try
            {
                var data = await _authService.GetRefreshToken(refreshTokenDto);
                //_logger.LogInformation($"Response Code: {data.StatusCode}\nResponse Message: {data.Message}; \n Response Data: {data.ResponseData}");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid token");
            }
        }

        [Authorize]
        [HttpGet("getUser")]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok("You are authenticated");

            }
            catch(Exception ex)
            {
                return BadRequest("Couldn't get the users");
            }
        } 

        [Authorize(Roles = "Admin")]
        [HttpGet("getUsersData")]
        public IActionResult GetAllUsersData()
        {
            try
            {
                return Ok("You are an admin, authorized");

            }
            catch (Exception ex)
            {
                return BadRequest("Couldn't get the users");
            }
        }

    }
}
