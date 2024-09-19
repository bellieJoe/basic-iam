using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return Ok("Hi");
        }
    }
}
