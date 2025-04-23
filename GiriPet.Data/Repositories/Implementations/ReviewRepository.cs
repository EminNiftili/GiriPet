using GiriPet.Data.Entities;
using GiriPet.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GiriPet.Data.Repositories.Implementations
{
    public class ReviewRepository : GenericRepository<ReviewDM>, IReviewRepository
    {
        public ReviewRepository(GiriPetDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ReviewDM>> GetReviewsByWalkerIdAsync(int walkerId)
        {
            return await _context.Reviews
                .Where(r => r.WalkerId == walkerId)
                .ToListAsync();
        }
    }

}
