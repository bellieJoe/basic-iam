using backend.Models.Dto;
using backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IService service) : Controller
    {
        private readonly IService _service = service;

        [HttpPost("signin")]
        public IActionResult SignIn(AuthDto authDto)
        {
            string? token = _service.AuthService.Authenticate(authDto);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
