using EngineMasters_BackEnd.Data.DTO;
using EngineMasters_BackEnd.Data.Models;

namespace EngineMasters_BackEnd.BLL.Interfaces
{
    public interface IRepairService
    {
        Task<IEnumerable<RepairBooking>> GetCustomerBookingsAsync(Guid customerId);
        Task<IEnumerable<RepairBooking>> GetAllBookingsAsync();
        Task CreateBookingAsync(Guid customerId, RepairBookingDto bookingDto);
        Task UpdateBookingAsync(Guid customerId, Guid id, RepairBookingDto bookingDto);
        Task DeleteBookingAsync(Guid customerId, Guid id);
    }
}