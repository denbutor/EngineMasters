// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using EngineMasters_BackEnd.Data.Models;
//
// namespace EngineMasters_BackEnd.DAL.Configuration
// {
//     public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
//     {
//         public void Configure(EntityTypeBuilder<Customer> builder)
//         {
//             builder.HasKey(c => c.Id);
//
//             builder.Property(c => c.Email)
//                 .IsRequired()
//                 .HasMaxLength(255);
//
//             builder.Property(c => c.FirstName)
//                 .IsRequired()
//                 .HasMaxLength(100);
//
//             builder.Property(c => c.LastName)
//                 .IsRequired()
//                 .HasMaxLength(100);
//
//             builder.Property(c => c.PhoneNumber)
//                 .IsRequired()
//                 .HasMaxLength(10);
//
//             builder.Property(c => c.Password)
//                 .IsRequired()
//                 .HasMaxLength(255);
//         }
//     }
// }

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EngineMasters_BackEnd.Data.Models;

namespace EngineMasters_BackEnd.DAL.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(c => c.Password)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
