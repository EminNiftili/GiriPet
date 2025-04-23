using GiriPet.Data.Entities;

namespace GiriPet.Data.Repositories.Abstractions
{
    public interface IAppointmentRepository : IGenericRepository<AppointmentDM>
    {
        Task<IEnumerable<AppointmentDM>> GetAppointmentsByWalkerIdAsync(int walkerId);
    }
}
