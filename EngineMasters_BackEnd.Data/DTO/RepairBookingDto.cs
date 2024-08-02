using System;
using System.ComponentModel.DataAnnotations;

namespace EngineMasters_BackEnd.Data.DTO
{
    public class RepairBookingDto : BaseDto
    {
        [Required]
        public string ProblemDescription { get; set; } = string.Empty;
        
        [Required]
        public bool IsResolved { get; set; }
        
        public new Guid Id { get; set; } 
        //public Guid CustomerId { get; set; }
        
    }
}