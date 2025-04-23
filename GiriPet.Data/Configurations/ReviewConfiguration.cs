using GiriPet.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GiriPet.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<ReviewDM>
    {
        public void Configure(EntityTypeBuilder<ReviewDM> builder)
        {
            builder.ToTable("Reviews");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Rating).IsRequired();
            builder.Property(r => r.Comment).HasMaxLength(1000);
            builder.Property(r => r.CreatedAt).IsRequired();

            builder.HasOne(r => r.Walker)
                   .WithMany(w => w.Reviews)
                   .HasForeignKey(r => r.WalkerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.User)
                   .WithMany(u => u.Reviews)
                   .HasForeignKey(r => r.UserId);
        }
    }

}
