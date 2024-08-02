// using EngineMasters_BackEnd.Data.DTO;
// using EngineMasters_BackEnd.Data.Models;
// using EngineMasters_BackEnd.DAL;
// using Microsoft.EntityFrameworkCore;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
//
// namespace EngineMasters_BackEnd.BLL
// {
//     public class RepairService : IRepairService
//     {
//         private readonly EngineMastersContext _context;
//
//         public RepairService(EngineMastersContext context)
//         {
//             _context = context;
//         }
//
//         public async Task<IEnumerable<RepairBooking>> GetCustomerBookingsAsync(string customerId)
//         {
//             return await _context.RepairBookings
//                 .Where(rb => rb.CustomerId == customerId)
//                 .ToListAsync();
//         }
//
//         public async Task<IEnumerable<RepairBooking>> GetAllBookingsAsync()
//         {
//             return await _context.RepairBookings.Include(rb => rb.Customer).ToListAsync();
//         }
//
//         public async Task CreateBookingAsync(Guid customerId, RepairBookingDto bookingDto)
//         {
//             var booking = new RepairBooking
//             {
//                 Description = bookingDto.Description,
//                 IsResolved = bookingDto.IsResolved,
//                 Date = bookingDto.Date,
//                 CustomerId = customerId
//             };
//
//             _context.RepairBookings.Add(booking);
//             await _context.SaveChangesAsync();
//         }
//
//         public async Task UpdateBookingAsync(Guid customerId, int id, RepairBookingDto bookingDto)
//         {
//             var booking = await _context.RepairBookings
//                 .Where(rb => rb.Id == id && rb.CustomerId == customerId)
//                 .FirstOrDefaultAsync();
//
//             if (booking != null)
//             {
//                 booking.Description = bookingDto.Description;
//                 booking.IsResolved = bookingDto.IsResolved;
//                 booking.Date = bookingDto.Date;
//
//                 _context.RepairBookings.Update(booking);
//                 await _context.SaveChangesAsync();
//             }
//         }
//
//         public async Task DeleteBookingAsync(Guid customerId, int id)
//         {
//             var booking = await _context.RepairBookings
//                 .Where(rb => rb.Id == id && rb.CustomerId == customerId)
//                 .FirstOrDefaultAsync();
//
//             if (booking != null)
//             {
//                 _context.RepairBookings.Remove(booking);
//                 await _context.SaveChangesAsync();
//             }
//         }
//     }
// }


using EngineMasters_BackEnd.BLL.Interfaces;
using EngineMasters_BackEnd.DAL;
using EngineMasters_BackEnd.Data.DTO;
using EngineMasters_BackEnd.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngineMasters_BackEnd.BLL.Services
{
    public class RepairService : IRepairService
    {
        private readonly EngineMastersContext _context;

        public RepairService(EngineMastersContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RepairBooking>> GetCustomerBookingsAsync(Guid customerId)
        {
            return await _context.RepairBookings
                .Where(rb => rb.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<RepairBooking>> GetAllBookingsAsync()
        {
            return await _context.RepairBookings.Include(rb => rb.Customer).ToListAsync();
        }

        public async Task CreateBookingAsync(Guid customerId, RepairBookingDto bookingDto)
        {
            var booking = new RepairBooking
            {
                Id = Guid.NewGuid(),  // Generate a new GUID
                CustomerId = customerId,
                ProblemDescription = bookingDto.ProblemDescription,
                IsResolved = bookingDto.IsResolved,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.RepairBookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookingAsync(Guid customerId, Guid id, RepairBookingDto bookingDto)
        {
            var booking = await _context.RepairBookings
                .Where(rb => rb.Id == id && rb.CustomerId == customerId)
                .FirstOrDefaultAsync();

            if (booking != null)
            {
                booking.ProblemDescription = bookingDto.ProblemDescription;
                booking.IsResolved = bookingDto.IsResolved;
                booking.UpdatedAt = DateTime.UtcNow;

                _context.RepairBookings.Update(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookingAsync(Guid customerId, Guid id)
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


