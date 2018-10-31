using System.ComponentModel.DataAnnotations;

namespace TaskManagment.Models
{
    class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2), MaxLength(15)]
        public string Name { get; set; }
    }
}
