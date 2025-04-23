using AutoMapper;
using GiriPet.Data.UnitOfWork;
using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Dtos;
using GiriPet.Logic.Enums;

namespace GiriPet.Logic.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new appointment and returns the appointment ID.
        /// </summary>
        public async Task<int> CreateAppointmentAsync(AppointmentDto dto)
        {
            var entity = _mapper.Map<Data.Entities.AppointmentDM>(dto);
            entity.StatusId = (int)AppointmentStatus.Pending; // default status

            await _unitOfWork.Appointments.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return entity.Id;
        }

        /// <summary>
        /// Gets all appointments for a given walker ID.
        /// </summary>
        public async Task<IEnumerable<AppointmentDto>> GetByWalkerIdAsync(int walkerId)
        {
            var list = await _unitOfWork.Appointments.FindAsync(a => a.WalkerId == walkerId);
            return _mapper.Map<IEnumerable<AppointmentDto>>(list);
        }

        /// <summary>
        /// Gets all appointments for a given pet ID.
        /// </summary>
        public async Task<AppointmentDto> GetByPetIdAsync(int petId)
        {
            var list = await _unitOfWork.Appointments.FindAsync(a => a.PetId == petId);
            return _mapper.Map<AppointmentDto>(list.FirstOrDefault());
        }

        /// <summary>
        /// Updates the status of an appointment.
        /// </summary>
        public async Task<bool> UpdateAppointmentStatusAsync(int appointmentId, AppointmentStatus newStatus)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(appointmentId);
            if (appointment == null)
                return false;

            appointment.StatusId = (int)newStatus;
            _unitOfWork.Appointments.Update(appointment);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
