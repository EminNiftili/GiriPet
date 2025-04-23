using GiriPet.Data.Entities;
using GiriPet.Data.Repositories.Abstractions;

namespace GiriPet.Data.Repositories.Implementations
{
    public class PaymentRepository : GenericRepository<PaymentDM>, IPaymentRepository
    {
        public PaymentRepository(GiriPetDbContext context) : base(context)
        {
        }
    }

}
