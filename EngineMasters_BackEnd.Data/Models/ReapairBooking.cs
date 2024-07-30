using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EngineMasters_BackEnd.Data.Models
{
    public class RepairBooking : BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        
        public Guid CustomerId { get; set; }
        
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; } = null!;
        
        [Required]
        public string ProblemDescription { get; set; } = string.Empty;
        
        public bool IsResolved { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}