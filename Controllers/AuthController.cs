using JWTAuthProject.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
       private readonly IServices _services;
        public AuthController(IServices services)
        {
                _services = services;
        }
        [HttpPost("login")]
        public IActionResult Login(UserDto request)
        {
            // Normally validate user from database

            if (request.Username != "admin" ||
                request.Password != "password")
            {
                return Unauthorized(
                    "Invalid username or password");
            }

            var token = _services.GenerateToken(
                1,
                request.Username,
                "Admin");

            return Ok(new
            {
                token
            });
        }
    }
}
