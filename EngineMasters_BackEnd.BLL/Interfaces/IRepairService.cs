using EngineMasters_BackEnd.Data.DTO;
using EngineMasters_BackEnd.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EngineMasters_BackEnd.BLL
{
    public interface IRepairService
    {
        Task<IEnumerable<RepairBooking>> GetCustomerBookingsAsync(string customerId);
        Task<IEnumerable<RepairBooking>> GetAllBookingsAsync();
        Task CreateBookingAsync(string customerId, RepairBookingDTO bookingDTO);
        Task UpdateBookingAsync(string customerId, int id, RepairBookingDTO bookingDTO);
        Task DeleteBookingAsync(string customerId, int id);
    }
}