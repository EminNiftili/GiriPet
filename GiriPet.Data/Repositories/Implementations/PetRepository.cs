using GiriPet.Data.Entities;
using GiriPet.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GiriPet.Data.Repositories.Implementations
{
    public class PetRepository : GenericRepository<PetDM>, IPetRepository
    {
        public PetRepository(GiriPetDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PetDM>> GetPetsByUserIdAsync(int userId)
        {
            return await _context.Pets
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }
    }

}
