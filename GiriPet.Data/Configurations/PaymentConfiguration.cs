using GiriPet.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GiriPet.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<PaymentDM>
    {
        public void Configure(EntityTypeBuilder<PaymentDM> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Amount).HasColumnType("decimal(10,2)");
            builder.Property(p => p.PaymentDate).IsRequired();
            builder.Property(p => p.PaymentStatus).IsRequired();

            builder.HasOne(p => p.Appointment)
                   .WithOne(a => a.Payment)
                   .HasForeignKey<PaymentDM>(p => p.AppointmentId);
        }
    }

}
