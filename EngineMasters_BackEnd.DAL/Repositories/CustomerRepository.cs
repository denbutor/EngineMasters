// using EngineMasters_BackEnd.Data.Models;
// using EngineMasters_BackEnd.DAL.Interfaces;
// using Microsoft.EntityFrameworkCore;
//
// namespace EngineMasters_BackEnd.DAL.Repositories
// {
//     public class CustomerRepository : Repository<Customer>, ICustomerRepository
//     {
//         public CustomerRepository(DbContext context) : base(context) { }
//
//     }
// }

using EngineMasters_BackEnd.Data.Models;
using EngineMasters_BackEnd.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EngineMasters_BackEnd.DAL.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EngineMastersContext databaseContext) : base(databaseContext)
        {
            
        }

    }
}