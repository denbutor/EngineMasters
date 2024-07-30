using EngineMasters_BackEnd.Data.DTO;
using EngineMasters_BackEnd.Data.Models;
using EngineMasters_BackEnd.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngineMasters_BackEnd.BLL
{
    public class RepairService : IRepairService
    {
        private readonly EngineMasters_BackEndContext _context;

        public RepairService(EngineMasters_BackEndContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RepairBooking>> GetCustomerBookingsAsync(string customerId)
        {
            return await _context.RepairBookings
                .Where(rb => rb.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<RepairBooking>> GetAllBookingsAsync()
        {
            return await _context.RepairBookings.Include(rb => rb.Customer).ToListAsync();
        }

        public async Task CreateBookingAsync(string customerId, RepairBookingDTO bookingDTO)
        {
            var booking = new RepairBooking
            {
                Description = bookingDTO.Description,
                IsResolved = bookingDTO.IsResolved,
                Date = bookingDTO.Date,
                CustomerId = customerId
            };

            _context.RepairBookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookingAsync(string customerId, int id, RepairBookingDTO bookingDTO)
        {
            var booking = await _context.RepairBookings
                .Where(rb => rb.Id == id && rb.CustomerId == customerId)
                .FirstOrDefaultAsync();

            if (booking != null)
            {
                booking.Description = bookingDTO.Description;
                booking.IsResolved = bookingDTO.IsResolved;
                booking.Date = bookingDTO.Date;

                _context.RepairBookings.Update(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookingAsync(string customerId, int id)
        {
            var booking = await _context.RepairBookings
                .Where(rb => rb.Id == id && rb.CustomerId == customerId)
                .FirstOrDefaultAsync();

            if (booking != null)
            {
                _context.RepairBookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
    }
}
