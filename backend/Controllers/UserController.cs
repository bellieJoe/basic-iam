using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        [Authorize]
        [HttpGet("")]
        public IActionResult Index()
        {
            return Ok("Hi");
        }
    }
}
