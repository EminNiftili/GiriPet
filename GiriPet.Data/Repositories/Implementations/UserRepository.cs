using GiriPet.Data.Entities;
using GiriPet.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GiriPet.Data.Repositories.Implementations
{
    public class UserRepository : GenericRepository<UserDM>, IUserRepository
    {
        public UserRepository(GiriPetDbContext context) : base(context)
        {
        }

        public async Task<UserDM?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }

}
