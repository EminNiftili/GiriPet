using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiriPet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalkersController : ControllerBase
    {
        private readonly IWalkerService _walkerService;

        public WalkersController(IWalkerService walkerService)
        {
            _walkerService = walkerService;
        }

        /// <summary>
        /// Creates a new walker profile.
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] WalkerDto dto)
        {
            var id = await _walkerService.CreateWalkerAsync(dto);
            return Ok(new { id });
        }

        /// <summary>
        /// Updates an existing walker profile.
        /// </summary>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] WalkerDto dto)
        {
            var success = await _walkerService.UpdateWalkerAsync(dto);
            if (!success)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Gets walker profile by user ID.
        /// </summary>
        [HttpGet("{userId}")]
        [Authorize]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var walker = await _walkerService.GetByUserIdAsync(userId);
            if (walker == null)
                return NotFound();

            return Ok(walker);
        }
    }
}
