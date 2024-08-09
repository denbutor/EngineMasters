using System.Reflection;
using EngineMasters_BackEnd.DAL.Configuration;
using Microsoft.EntityFrameworkCore;
using EngineMasters_BackEnd.Data.Models;

namespace EngineMasters_BackEnd.DAL
{
    public class EngineMastersContext : DbContext
    {
        public EngineMastersContext(DbContextOptions<EngineMastersContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<RepairBooking> RepairBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations
            // modelBuilder.ApplyConfiguration(new RepairBookingConfiguration());
            // modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}