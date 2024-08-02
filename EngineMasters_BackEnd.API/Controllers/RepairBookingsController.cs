// using EngineMasters_BackEnd.Data.DTO;
// using EngineMasters_BackEnd.Data.Models;
// using EngineMasters_BackEnd.BLL;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
// using System.Security.Claims;
// using System.Threading.Tasks;
//
// namespace EngineMasters_BackEnd.API.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     [Authorize]
//     public class RepairBookingsController : ControllerBase
//     {
//         private readonly IRepairService _repairService;
//
//         public RepairBookingsController(IRepairService repairService)
//         {
//             _repairService = repairService;
//         }
//
//         [HttpGet]
//         [Authorize(Policy = "RequireCustomerRole")]
//         public async Task<ActionResult<IEnumerable<RepairBooking>>> GetCustomerBookings()
//         {
//             var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//
//             if (string.IsNullOrEmpty(userId))
//             {
//                 return Unauthorized();
//             }
//
//             var bookings = await _repairService.GetCustomerBookingsAsync(userId);
//             return Ok(bookings);
//         }
//
//         [HttpPost]
//         [Authorize(Policy = "RequireCustomerRole")]
//         public async Task<ActionResult> CreateBooking([FromBody] RepairBookingDto bookingDto)
//         {
//             var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//
//             if (string.IsNullOrEmpty(userId))
//             {
//                 return Unauthorized();
//             }
//
//             await _repairService.CreateBookingAsync(Guid.Parse(userId), bookingDto);
//             return CreatedAtAction(nameof(GetCustomerBookings), new { id = bookingDto.Id }, bookingDto);
//         }
//
//         [HttpPut("{id}")]
//         [Authorize(Policy = "RequireCustomerRole")]
//         public async Task<ActionResult> UpdateBooking(int id, [FromBody] RepairBookingDto bookingDto)
//         {
//             var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//
//             if (string.IsNullOrEmpty(userId))
//             {
//                 return Unauthorized();
//             }
//
//             await _repairService.UpdateBookingAsync(Guid.Parse(userId), id, bookingDto);
//             return NoContent();
//         }
//
//         [HttpDelete("{id}")]
//         [Authorize(Policy = "RequireCustomerRole")]
//         public async Task<ActionResult> DeleteBooking(int id)
//         {
//             var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//
//             if (string.IsNullOrEmpty(userId))
//             {
//                 return Unauthorized();
//             }
//
//             await _repairService.DeleteBookingAsync(Guid.Parse(userId), id);
//             return NoContent();
//         }
//
//     }
// }


using EngineMasters_BackEnd.BLL.Interfaces;
using EngineMasters_BackEnd.Data.DTO;
using EngineMasters_BackEnd.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out Guid userId))
            {
                return Unauthorized();
            }

            var bookings = await _repairService.GetCustomerBookingsAsync(userId);
            return Ok(bookings);
        }

        [HttpPost]
        [Authorize(Policy = "RequireCustomerRole")]
        public async Task<ActionResult> CreateBooking([FromBody] RepairBookingDto bookingDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out Guid userId))
            {
                return Unauthorized();
            }

            await _repairService.CreateBookingAsync(userId, bookingDto);
            return CreatedAtAction(nameof(GetCustomerBookings), new { id = bookingDto.Id }, bookingDto);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "RequireCustomerRole")]
        public async Task<ActionResult> UpdateBooking(Guid id, [FromBody] RepairBookingDto bookingDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out Guid userId))
            {
                return Unauthorized();
            }

            await _repairService.UpdateBookingAsync(userId, id, bookingDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "RequireCustomerRole")]
        public async Task<ActionResult> DeleteBooking(Guid id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out Guid userId))
            {
                return Unauthorized();
            }

            await _repairService.DeleteBookingAsync(userId, id);
            return NoContent();
        }
    }
}




