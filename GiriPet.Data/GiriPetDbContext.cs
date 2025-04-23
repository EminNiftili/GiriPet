using GiriPet.Data.Configurations;
using GiriPet.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GiriPet.Data
{
    public class GiriPetDbContext : DbContext
    {
        public GiriPetDbContext(DbContextOptions<GiriPetDbContext> options) : base(options)
        {
        }
        public DbSet<UserDM> Users { get; set; } = null!;
        public DbSet<PetDM> Pets { get; set; } = null!;
        public DbSet<WalkerDM> Walkers { get; set; } = null!;
        public DbSet<AppointmentDM> Appointments { get; set; } = null!;
        public DbSet<ReviewDM> Reviews { get; set; } = null!;
        public DbSet<PaymentDM> Payments { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("giri");

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PetConfiguration());
            modelBuilder.ApplyConfiguration(new WalkerConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        }
    }
}
