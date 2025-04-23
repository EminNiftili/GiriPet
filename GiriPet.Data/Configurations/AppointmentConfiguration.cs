using GiriPet.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GiriPet.Data.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<AppointmentDM>
    {
        public void Configure(EntityTypeBuilder<AppointmentDM> builder)
        {
            builder.ToTable("Appointments");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.StatusId).IsRequired().HasMaxLength(30);
            builder.Property(a => a.Price).HasColumnType("decimal(10,2)");

            builder.HasOne(a => a.Pet)
                   .WithMany(p => p.Appointments)
                   .HasForeignKey(a => a.PetId);

            builder.HasOne(a => a.Walker)
                   .WithMany(w => w.Appointments)
                   .HasForeignKey(a => a.WalkerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Payment)
                   .WithOne(p => p.Appointment)
                   .HasForeignKey<PaymentDM>(p => p.AppointmentId);
        }
    }

}
