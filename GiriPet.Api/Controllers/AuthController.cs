using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GiriPet.Api.Controllers
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            var token = await _authService.RegisterAsync(dto);
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var token = await _authService.LoginWithEmailAsync(dto.Email, dto.Password);
            if (token == null)
                return Unauthorized("Invalid credentials.");

            return Ok(new { token });
        }

        [HttpPost("google")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] string idToken)
        {
            var token = await _authService.LoginWithGoogleAsync(idToken);
            if (token == null)
                return Unauthorized("Google authentication failed.");

            return Ok(new { token });
        }

        [HttpPost("facebook")]
        public async Task<IActionResult> LoginWithFacebook([FromBody] string accessToken)
        {
            var token = await _authService.LoginWithFacebookAsync(accessToken);
            if (token == null)
                return Unauthorized("Facebook authentication failed.");

            return Ok(new { token });
        }

        [HttpPost("apple")]
        public async Task<IActionResult> LoginWithApple([FromBody] string identityToken)
        {
            var token = await _authService.LoginWithAppleAsync(identityToken);
            if (token == null)
                return Unauthorized("Apple authentication failed.");

            return Ok(new { token });
        }
    }
}
