using GiriPet.Logic.Dtos;

namespace GiriPet.Logic.Abstractions
{
    public interface IWalkerService
    {
        /// <summary>
        /// Creates a new walker profile.
        /// </summary>
        Task<int> CreateWalkerAsync(WalkerDto dto);

        /// <summary>
        /// Updates an existing walker profile.
        /// </summary>
        Task<bool> UpdateWalkerAsync(WalkerDto dto);

        /// <summary>
        /// Gets walker profile by user ID.
        /// </summary>
        Task<WalkerDto?> GetByUserIdAsync(int userId);
    }
}
