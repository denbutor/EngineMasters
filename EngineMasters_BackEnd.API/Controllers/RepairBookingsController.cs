using EngineMasters_BackEnd.Data.DTO;
using EngineMasters_BackEnd.Data.Models;
using EngineMasters_BackEnd.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EngineMasters_BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RepairBookingsController : ControllerBase
    {
        private readonly IRepairService _repairService;

        public RepairBookingsController(IRepairService repairService)
        {
            _repairService = repairService;
        }

        [HttpGet]
        [Authorize(Policy = "RequireCustomerRole")]
        public async Task<ActionResult<IEnumerable<RepairBooking>>> GetCustomerBookings()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var bookings = await _repairService.GetCustomerBookingsAsync(userId);
            return Ok(bookings);
        }

        [HttpPost]
        [Authorize(Policy = "RequireCustomerRole")]
        public async Task<ActionResult> CreateBooking([FromBody] RepairBookingDTO bookingDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _repairService.CreateBookingAsync(userId, bookingDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "RequireCustomerRole")]
        public async Task<ActionResult> UpdateBooking(int id, [FromBody] RepairBookingDTO bookingDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _repairService.UpdateBookingAsync(userId, id, bookingDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "RequireCustomerRole")]
        public async Task<ActionResult> DeleteBooking(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _repairService.DeleteBookingAsync(userId, id);
            return Ok();
        }

        [HttpGet("admin")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<ActionResult<IEnumerable<RepairBooking>>> GetAllBookings()
        {
            var bookings = await _repairService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [HttpPost("admin")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<ActionResult> CreateAdminBooking([FromBody] RepairBookingDTO bookingDTO)
        {
            await _repairService.CreateBookingAsync(null, bookingDTO);
            return Ok();
        }
    }
}
