using GiriPet.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GiriPet.Data.Configurations
{
    public class WalkerConfiguration : IEntityTypeConfiguration<WalkerDM>
    {
        public void Configure(EntityTypeBuilder<WalkerDM> builder)
        {
            builder.ToTable("Walkers");

            builder.HasKey(w => w.Id);

            builder.Property(w => w.Bio).IsRequired().HasMaxLength(500);
            builder.Property(w => w.City).IsRequired().HasMaxLength(100);
            builder.Property(w => w.Rating).HasPrecision(2, 1);
            builder.Property(w => w.ExperienceYears).IsRequired();

            builder.HasOne(w => w.User)
                   .WithMany()
                   .HasForeignKey(w => w.UserId);

            builder.HasMany(w => w.Appointments)
                   .WithOne(a => a.Walker)
                   .HasForeignKey(a => a.WalkerId);

            builder.HasMany(w => w.Reviews)
                   .WithOne(r => r.Walker)
                   .HasForeignKey(r => r.WalkerId);
        }
    }

}
