using GiriPet.Logic.Dtos;

namespace GiriPet.Logic.Abstractions
{
    public interface IUserService
    {
        /// <summary>
        /// Returns user details by user ID.
        /// </summary>
        Task<UserDto?> GetByIdAsync(int userId);

        /// <summary>
        /// Updates user profile data.
        /// </summary>
        Task<bool> UpdateUserAsync(UserUpdateDto dto);

        Task<bool> DeleteUserByIdAsync(int userId);
    }
}
