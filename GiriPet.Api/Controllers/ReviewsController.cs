using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GiriPet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        /// <summary>
        /// Creates a new review for a walker.
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ReviewDto dto)
        {
            var id = await _reviewService.CreateReviewAsync(dto);
            return Ok(new { id });
        }

        /// <summary>
        /// Gets all reviews for a specific walker.
        /// </summary>
        [HttpGet("walker/{walkerId}")]
        [Authorize]
        public async Task<IActionResult> GetByWalkerId(int walkerId)
        {
            var reviews = await _reviewService.GetReviewsByWalkerIdAsync(walkerId);
            return Ok(reviews);
        }
    }
}
