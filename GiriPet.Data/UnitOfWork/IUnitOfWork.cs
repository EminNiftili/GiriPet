using GiriPet.Data.Repositories.Abstractions;

namespace GiriPet.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IPetRepository Pets { get; }
        IWalkerRepository Walkers { get; }
        IAppointmentRepository Appointments { get; }
        IReviewRepository Reviews { get; }
        IPaymentRepository Payments { get; }

        Task<int> SaveChangesAsync();
    }
}
