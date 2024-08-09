// using EngineMasters_BackEnd.Data.Models;
//
// namespace EngineMasters_BackEnd.DAL.Interfaces
// {
//     public interface ICustomerRepository : IRepository<Customer>
//     {
//         
//     }
// }

using EngineMasters_BackEnd.Data.Models;

namespace EngineMasters_BackEnd.DAL.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        
    }
}

