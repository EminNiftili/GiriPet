using GiriPet.Data.Repositories.Abstractions;

namespace GiriPet.Data.UnitOfWork
{
    public class GiriPetUnitOfWork : IUnitOfWork
    {
        private readonly GiriPetDbContext _context;

        public IUserRepository Users { get; }
        public IPetRepository Pets { get; }
        public IWalkerRepository Walkers { get; }
        public IAppointmentRepository Appointments { get; }
        public IReviewRepository Reviews { get; }
        public IPaymentRepository Payments { get; }

        public GiriPetUnitOfWork(GiriPetDbContext context,
                                 IUserRepository userRepo,
                                 IPetRepository petRepo,
                                 IWalkerRepository walkerRepo,
                                 IAppointmentRepository appointmentRepo,
                                 IReviewRepository reviewRepo,
                                 IPaymentRepository paymentRepo)
        {
            _context = context;
            Users = userRepo;
            Pets = petRepo;
            Walkers = walkerRepo;
            Appointments = appointmentRepo;
            Reviews = reviewRepo;
            Payments = paymentRepo;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
