using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GiriPet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        /// <summary>
        /// Creates a new pet.
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] PetDto dto)
        {
            var id = await _petService.CreatePetAsync(dto);
            if(id == -1)
            {
                return Unauthorized();
            }
            return Ok(new { id });
        }

        /// <summary>
        /// Updates an existing pet.
        /// </summary>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] PetDto dto)
        {
            var success = await _petService.UpdatePetAsync(dto);
            if (!success)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Gets all pets by user ID.
        /// </summary>
        [HttpGet("user/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var pets = await _petService.GetPetsByUserIdAsync(userId);
            return Ok(pets);
        }

        /// <summary>
        /// Gets pet details by ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var pet = await _petService.GetByIdAsync(id);
            if (pet == null)
                return NotFound();

            return Ok(pet);
        }
    }
}
