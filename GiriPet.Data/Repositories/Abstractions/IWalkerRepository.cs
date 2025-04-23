using GiriPet.Data.Entities;

namespace GiriPet.Data.Repositories.Abstractions
{
    public interface IWalkerRepository : IGenericRepository<WalkerDM>
    {
        Task<IEnumerable<WalkerDM>> GetByCityAsync(string city);
    }
}
