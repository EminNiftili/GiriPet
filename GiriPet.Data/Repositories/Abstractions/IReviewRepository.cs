using GiriPet.Data.Entities;

namespace GiriPet.Data.Repositories.Abstractions
{
    public interface IReviewRepository : IGenericRepository<ReviewDM>
    {
        Task<IEnumerable<ReviewDM>> GetReviewsByWalkerIdAsync(int walkerId);
    }
}
