using AutoMapper;
using GiriPet.Data.UnitOfWork;
using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Dtos;

namespace GiriPet.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

            user.FullName = dto.FullName;
            user.PhoneNumber = dto.PhoneNumber;

            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
