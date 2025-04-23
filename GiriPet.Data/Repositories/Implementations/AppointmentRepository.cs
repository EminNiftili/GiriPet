using GiriPet.Data.Entities;
using GiriPet.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GiriPet.Data.Repositories.Implementations
{
    public class AppointmentRepository : GenericRepository<AppointmentDM>, IAppointmentRepository
    {
        public AppointmentRepository(GiriPetDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AppointmentDM>> GetAppointmentsByWalkerIdAsync(int walkerId)
        {
            return await _context.Appointments
                .Where(a => a.WalkerId == walkerId)
                .ToListAsync();
        }
    }

}
