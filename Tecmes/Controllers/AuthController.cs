using Microsoft.AspNetCore.Mvc;
using Tecmes.Application.Services.Auth;
using Tecmes.Entities;
using Tecmes.Models.Auth;

namespace Tecmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) : base()
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async ValueTask<IActionResult> Login([FromBody] LoginModel model)
        {
            var passwordMd5 = await _authService.CalculatePassword(model.Password);

            if (passwordMd5.IsFailure)
            {
                return BadRequest("Senha incorreta");
            }

            // If authentication is successful, generate a JWT token and return it to the client
            var result = _authService.GenerateJwtToken(model.Username, passwordMd5.Value);

            return Ok(result);
        }

        [HttpPost("register")]
        public async ValueTask<IActionResult> Register([FromBody] LoginModel model)
        {
            var passwordMd5 = await _authService.CalculatePassword(model.Password);

            if (passwordMd5.IsFailure)
            {
                return BadRequest(passwordMd5.Error);
            }

            var result = await _authService.RegisterUser(model.Username, passwordMd5.Value);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }
    }
}
