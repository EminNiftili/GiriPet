using GiriPet.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GiriPet.Data.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<PetDM>
    {
        public void Configure(EntityTypeBuilder<PetDM> builder)
        {
            builder.ToTable("Pets");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Species).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Breed).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Size).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Notes).HasMaxLength(500);
            builder.Property(p => p.ImagePath).HasMaxLength(500);

            builder.HasOne(p => p.User)
                   .WithMany(u => u.Pets)
                   .HasForeignKey(p => p.UserId);

            builder.HasMany(p => p.Appointments)
                   .WithOne(a => a.Pet)
                   .HasForeignKey(a => a.PetId);
        }
    }

}
