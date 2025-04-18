using Ecommerce_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController() { }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok();
        }
    }
}
