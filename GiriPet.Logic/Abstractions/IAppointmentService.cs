using GiriPet.Logic.Dtos;
using GiriPet.Logic.Enums;

namespace GiriPet.Logic.Abstractions
{
    public interface IAppointmentService
    {
        /// <summary>
        /// Creates a new appointment and returns the created appointment ID.
        /// </summary>
        Task<int> CreateAppointmentAsync(AppointmentDto dto);

        /// <summary>
        /// Gets appointments for a specific walker.
        /// </summary>
        Task<IEnumerable<AppointmentDto>> GetByWalkerIdAsync(int walkerId);

        /// <summary>
        /// Gets appointments for a specific pet.
        /// </summary>
        Task<AppointmentDto> GetByPetIdAsync(int petId);

        /// <summary>
        /// Updates the status of an appointment (Confirmed, Cancelled, Completed, etc.).
        /// </summary>
        Task<bool> UpdateAppointmentStatusAsync(int appointmentId, AppointmentStatus newStatus);
    }
}
