using GiriPet.Logic.Dtos;

namespace GiriPet.Logic.Abstractions
{
    public interface IPetService
    {
        /// <summary>
        /// Creates a new pet and returns the created pet ID.
        /// </summary>
        Task<int> CreatePetAsync(PetDto dto);

        /// <summary>
        /// Updates an existing pet.
        /// </summary>
        Task<bool> UpdatePetAsync(PetDto dto);

        /// <summary>
        /// Gets all pets associated with a specific user.
        /// </summary>
        Task<IEnumerable<PetDto>> GetPetsByUserIdAsync(int userId);

        /// <summary>
        /// Gets pet details by ID.
        /// </summary>
        Task<PetDto?> GetByIdAsync(int id);
    }
}
