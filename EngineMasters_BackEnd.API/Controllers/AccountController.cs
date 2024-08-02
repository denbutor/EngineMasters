using Microsoft.AspNetCore.Mvc;
using EngineMasters_BackEnd.Data.Models;
using EngineMasters_BackEnd.Data.DTO;
using System.Linq;
using System.Threading.Tasks;
using EngineMasters_BackEnd.DAL;

namespace EngineMasters_BackEnd.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly EngineMastersContext _context;

        public AccountController(EngineMastersContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var customer = new Customer
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password // У реальному житті паролі потрібно хешувати
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            var customer = _context.Customers.FirstOrDefault
                (c => (c.Email == model.Email || c.PhoneNumber == model.PhoneNumber) && c.Password == model.Password);
            if (customer == null)
            {
                return Unauthorized();
            }

            // Токен авторизації можна реалізувати тут

            return Ok();
        }
    }
}

// using Microsoft.AspNetCore.Mvc;
// using EngineMasters_BackEnd.Data.Models;
// using EngineMasters_BackEnd.Data.DTO;
// using System.Linq;
// using System.Threading.Tasks;
// using EngineMasters_BackEnd.DAL;
//
// namespace EngineMasters_BackEnd.API.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class AccountController : ControllerBase
//     {
//         private readonly EngineMastersContext _context;
//
//         public AccountController(EngineMastersContext context)
//         {
//             _context = context;
//         }
//
//         [HttpPost("register")]
//         public async Task<IActionResult> Register(RegisterModel model)
//         {
//             var customer = new Customer
//             {
//                 Email = model.Email,
//                 FirstName = model.FirstName,
//                 LastName = model.LastName,
//                 PhoneNumber = model.PhoneNumber,
//                 Password = model.Password // У реальному житті паролі потрібно хешувати
//             };
//
//             _context.Customers.Add(customer);
//             await _context.SaveChangesAsync();
//
//             return Ok();
//         }
//
//         [HttpPost("login")]
//         public IActionResult Login(LoginModel model)
//         {
//             var customer = _context.Customers.FirstOrDefault
//                 (c => (c.Email == model.Email || c.PhoneNumber == model.PhoneNumber) && c.Password == model.Password);
//             if (customer == null)
//             {
//                 return Unauthorized();
//             }
//
//             // Токен авторизації можна реалізувати тут
//
//             return Ok();
//         }
//     }
// }
