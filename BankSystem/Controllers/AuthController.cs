using BankSystem.Model.Api;
using BankSystem.Service.IService;
using BankSystem.Service.JWT;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ICaptchaService _captchaService;

        public AuthController(IAuthService authService, ICaptchaService captchaService)
        {
            _authService = authService;
            _captchaService = captchaService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            // Step 1: Validate captcha first
            //if (string.IsNullOrEmpty(model.CaptchaToken))
            //    return BadRequest(new { message = "Captcha token is required." });

            //var isCaptchaValid = await _captchaService.VerifyCaptchaAsync(model.CaptchaToken);
            //if (!isCaptchaValid)
            //    return BadRequest(new { message = "Captcha verification failed." });

            // Step 2: Authenticate user
            var response = await _authService.AuthenticateAsync(model);
            if (response == null)
                return Unauthorized(new { message = "Invalid username or password." });

            return Ok(response);
        }

        // Optional endpoint: use only if you want to test captcha separately from frontend
        [HttpPost("verify-captcha")]
        public async Task<IActionResult> VerifyCaptcha([FromBody] string token)
        {
            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Captcha token is required" });

            bool isValid = await _captchaService.VerifyCaptchaAsync(token);
            if (!isValid)
                return BadRequest(new { message = "Captcha verification failed" });

            return Ok(new { message = "Captcha verified successfully" });
        }
    }
}
