using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagment.Models
{
    public  class Worker
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(2), MaxLength(15)]
        public string Name { get; set; }
        [Required]
        [MinLength(2), MaxLength(10)]
        public string UserName { get; set; }
        [Required]
        [MinLength(6), MaxLength(10)]
        public string Password { get; set; }
        public int JobId { get; set; }
        [Required]
        [MinLength(6), MaxLength(30)]
        public string EMail { get; set; }
        public int? ManagerId { get; set; }
        
    }
}
