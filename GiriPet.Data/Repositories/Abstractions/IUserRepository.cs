using GiriPet.Data.Entities;

namespace GiriPet.Data.Repositories.Abstractions
{
    public interface IUserRepository : IGenericRepository<UserDM>
    {
        Task<UserDM?> GetByEmailAsync(string email);
    }
}
