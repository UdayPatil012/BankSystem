using BankSystem.Model.Api;
using BankSystem.Service.JWT;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var response = await _authService.AuthenticateAsync(model);
            if (response == null)
                return Unauthorized(new { message = "Invalid username or password" });

            return Ok(response);
        }
    }
}
