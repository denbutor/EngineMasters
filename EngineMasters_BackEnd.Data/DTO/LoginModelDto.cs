using System.ComponentModel.DataAnnotations;

namespace EngineMasters_BackEnd.Data.DTO
{
    public class LoginModel : BaseDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}