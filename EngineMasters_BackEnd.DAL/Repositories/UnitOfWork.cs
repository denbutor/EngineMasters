// using System.Threading.Tasks;
// using EngineMasters_BackEnd.DAL.Interfaces;
// using EngineMasters_BackEnd.DAL.Repositories;
//
// namespace EngineMasters_BackEnd.DAL.Repositories
// {
//     public class UnitOfWork : IUnitOfWork
//     {
//         private readonly EngineMastersContext _context;
//         private ICustomerRepository _customers;
//         private IRepairBookingRepository _repairBookings;
//
//         public UnitOfWork(EngineMastersContext context)
//         {
//             _context = context;
//         }
//
//         public ICustomerRepository Customers
//         {
//             get
//             {
//                 return _customers ??= new CustomerRepository(_context);
//             }
//         }
//
//         public IRepairBookingRepository RepairBookings
//         {
//             get
//             {
//                 return _repairBookings ??= new RepairBookingRepository(_context);
//             }
//         }
//
//         public async Task<int> SaveAsync()
//         {
//             return await _context.SaveChangesAsync();
//         }
//
//         public void Dispose()
//         {
//             _context.Dispose();
//         }
//     }
// }

using BusStation.DAL.Interfaces;
using EngineMasters_BackEnd.DAL;
using EngineMasters_BackEnd.DAL.Interfaces;

namespace BusStation.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    protected readonly EngineMastersContext databaseContext;
    public ICustomerRepository CustomerRepository { get; }
    public IRepairBookingRepository RepairBookingRepository { get; }
    

    public UnitOfWork(
        EngineMastersContext databaseContext,
        ICustomerRepository customerRepository,
        IRepairBookingRepository repairBookingRepository, 
        
    {
        this.databaseContext = databaseContext;
        CustomerRepository = customerRepository;
        RepairBookingRepository = repairBookingRepository;
        
    }

    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}