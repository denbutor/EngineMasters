// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using EngineMasters_BackEnd.Data.Models;
//
// namespace EngineMasters_BackEnd.DAL.Configuration
// {
//     public class RepairBookingConfiguration : IEntityTypeConfiguration<RepairBooking>
//     {
//         public void Configure(EntityTypeBuilder<RepairBooking> builder)
//         {
//             builder.HasKey(rb => rb.Id);
//
//             builder.Property(rb => rb.ProblemDescription)
//                 .IsRequired()
//                 .HasMaxLength(1000);
//
//             builder.Property(rb => rb.IsResolved)
//                 .IsRequired()
//                 .HasDefaultValue(false);
//
//             builder.Property(rb => rb.CreatedAt)
//                 .IsRequired();
//
//             builder.Property(rb => rb.UpdatedAt)
//                 .IsRequired();
//
//             builder.HasOne(rb => rb.Customer)
//                 .WithMany()
//                 .HasForeignKey(rb => rb.CustomerId);
//         }
//     }
// }

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EngineMasters_BackEnd.Data.Models;

namespace EngineMasters_BackEnd.DAL.Configuration
{
    public class RepairBookingConfiguration : IEntityTypeConfiguration<RepairBooking>
    {
        public void Configure(EntityTypeBuilder<RepairBooking> builder)
        {
            builder.HasKey(rb => rb.Id);

            builder.Property(rb => rb.ProblemDescription)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(rb => rb.IsResolved)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(rb => rb.CreatedAt)
                .IsRequired();

            builder.Property(rb => rb.UpdatedAt)
                .IsRequired();

            builder.HasOne(rb => rb.Customer)
                .WithMany()
                .HasForeignKey(rb => rb.CustomerId);
        }
    }
}
