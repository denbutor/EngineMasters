// using EngineMasters_BackEnd.Data.Models;
// using EngineMasters_BackEnd.DAL.Interfaces;
// using Microsoft.EntityFrameworkCore;
//
// namespace EngineMasters_BackEnd.DAL.Repositories
// {
//     public class RepairBookingRepository : Repository<RepairBooking>, IRepairBookingRepository
//     {
//         public RepairBookingRepository(DbContext context) : base(context) { }
//
//     }
// }

using EngineMasters_BackEnd.Data.Models;
using EngineMasters_BackEnd.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EngineMasters_BackEnd.DAL.Repositories
{
    public class RepairBookingRepository : GenericRepository<RepairBooking>, IRepairBookingRepository
    {
        public RepairBookingRepository(EngineMastersContext databaseContext) : base(databaseContext)
        {
            
        }

    }
}