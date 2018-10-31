using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagment.Models
{
   public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2), MaxLength(25)]
        public string Name { get; set; }
        public int TeamLeaderId { get; set; }
        [Required]
        [MinLength(2), MaxLength(15)]
        public string Customer { get; set; }
        [Required]
        public int DevelopHours { get; set; }
        [Required]
        public int QAHours { get; set; }
        [Required]
        public int UiUxHours { get; set; }
        [Required]
        public DateTime StartDate { get; set; } = DateTime.Today;
        [Required]
        public DateTime EndDate { get; set; }
    }
}
