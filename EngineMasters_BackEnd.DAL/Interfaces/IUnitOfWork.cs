using System;
using System.Threading.Tasks;
using EngineMasters_BackEnd.DAL.Repositories;

namespace EngineMasters_BackEnd.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IRepairBookingRepository RepairBookings { get; }
        //Task<int> SaveAsync();
        Task SaveChangesAsync();
    }
}