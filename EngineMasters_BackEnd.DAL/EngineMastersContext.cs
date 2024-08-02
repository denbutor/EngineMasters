using EngineMasters_BackEnd.DAL.Configuration;
using Microsoft.EntityFrameworkCore;
using EngineMasters_BackEnd.Data.Models;

namespace EngineMasters_BackEnd.DAL
{
    public class EngineMastersContext : DbContext // Виправлено ім'я класу
    {
        public EngineMastersContext(DbContextOptions<EngineMastersContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<RepairBooking> RepairBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations if you have any
            modelBuilder.ApplyConfiguration(new RepairBookingConfiguration()); // Переконайтеся, що цей клас існує
        }
    }
}