using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GiriPet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UsersController(IUserService userService, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        /// <summary>
        /// Gets user information by user ID.
        /// </summary>
        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Gets user information from token.
        /// </summary>
        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetMyProfile()
        {
            var authHeader = this.HttpContext.Request.Headers.Authorization.FirstOrDefault();
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                return Unauthorized();
            }
            var token = authHeader.Substring("Bearer ".Length).Trim();
            var userId = _tokenService.GetUserIdFromToken(token);
            if(userId == -1)
            {
                return BadRequest();
            }
            var user = await _userService.GetByIdAsync(userId);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Updates user profile data.
        /// </summary>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto dto)
        {
            var success = await _userService.UpdateUserAsync(dto);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
