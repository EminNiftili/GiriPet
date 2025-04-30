using AutoMapper;
using GiriPet.Data.UnitOfWork;
using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Dtos;
using GiriPet.Logic.Enums;

namespace GiriPet.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IFileService _fileService;
        public UserService(IUnitOfWork unitOfWork, 
                           IMapper mapper, 
                           ITokenService tokenService, 
                           IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
            _fileService = fileService;
        }

        /// <summary>
        /// Retrieves user data by ID.
        /// </summary>
        public async Task<UserDto?> GetByIdAsync(int userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        /// <summary>
        /// Updates the user's full name and phone number.
        /// </summary>
        public async Task<bool> UpdateUserAsync(UserUpdateDto dto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(dto.Id);
            if (user == null)
                return false;

            if(dto.ImageAction == ImageAction.Updated)
            {
                string directory = $"{user.Id}\\";
                var imageContent = Convert.FromBase64String(dto.ImageAsBase64);
                user.ImagePath = _fileService.Upload(directory, imageContent);
            }
            else if (dto.ImageAction == ImageAction.Removed)
            {
                user.ImagePath = null;
            }

            user.FullName = dto.FullName;
            user.PhoneNumber = dto.PhoneNumber;

            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUserByIdAsync(int userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            var appointments = await _unitOfWork.Appointments.FindAsync(x => x.Pet.UserId == userId && x.StatusId != (int)AppointmentStatus.Completed);
            var payments = await _unitOfWork.Payments.FindAsync(x => x.Appointment.Pet.UserId == userId && x.PaymentStatus == (int) PaymentStatus.Completed);
            var hasAnyAppointment = appointments.Any();
            var hasAnyDebt = payments.Any();
            if (user  == null || hasAnyAppointment || hasAnyDebt)
            {
                return false;
            }
            var pets = await _unitOfWork.Pets.FindAsync(x => x.UserId == userId);
            foreach ( var pet in pets)
            {
                _unitOfWork.Pets.Remove(pet);
            }
            await _unitOfWork.SaveChangesAsync();
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
