using GiriPet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiriPet.Data.Repositories.Abstractions
{
    public interface IPetRepository : IGenericRepository<PetDM>
    {
        Task<IEnumerable<PetDM>> GetPetsByUserIdAsync(int userId);
    }
}
