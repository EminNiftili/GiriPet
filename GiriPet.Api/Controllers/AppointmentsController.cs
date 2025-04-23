using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Dtos;
using GiriPet.Logic.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GiriPet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        /// <summary>
        /// Creates a new appointment.
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] AppointmentDto dto)
        {
            var id = await _appointmentService.CreateAppointmentAsync(dto);
            return Ok(new { id });
        }

        /// <summary>
        /// Gets all appointments for a specific walker.
        /// </summary>
        [HttpGet("walker/{walkerId}")]
        [Authorize]
        public async Task<IActionResult> GetByWalkerId(int walkerId)
        {
            var appointments = await _appointmentService.GetByWalkerIdAsync(walkerId);
            return Ok(appointments);
        }

        /// <summary>
        /// Gets all appointments for a specific pet.
        /// </summary>
        [HttpGet("pet/{petId}")]
        [Authorize]
        public async Task<IActionResult> GetByPetId(int petId)
        {
            var appointments = await _appointmentService.GetByPetIdAsync(petId);
            return Ok(appointments);
        }

        /// <summary>
        /// Updates the status of an appointment.
        /// </summary>
        [HttpPatch("{appointmentId}/status")]
        [Authorize]
        public async Task<IActionResult> UpdateStatus(int appointmentId, [FromQuery] int statusId)
        {
            var success = await _appointmentService.UpdateAppointmentStatusAsync(appointmentId, (AppointmentStatus)statusId);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
