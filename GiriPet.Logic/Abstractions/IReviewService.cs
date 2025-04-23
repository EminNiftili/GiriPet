using GiriPet.Logic.Dtos;

namespace GiriPet.Logic.Abstractions
{
    public interface IReviewService
    {
        /// <summary>
        /// Creates a new review and rating for a walker.
        /// </summary>
        Task<int> CreateReviewAsync(ReviewDto dto);

        /// <summary>
        /// Retrieves all reviews written for a specific walker.
        /// </summary>
        Task<IEnumerable<ReviewDto>> GetReviewsByWalkerIdAsync(int walkerId);
    }
}
