using GiriPet.Data.Entities;
using GiriPet.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GiriPet.Data.Repositories.Implementations
{
    public class WalkerRepository : GenericRepository<WalkerDM>, IWalkerRepository
    {
        public WalkerRepository(GiriPetDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<WalkerDM>> GetByCityAsync(string city)
        {
            return await _context.Walkers
                .Where(w => w.City == city)
                .ToListAsync();
        }
    }

}
