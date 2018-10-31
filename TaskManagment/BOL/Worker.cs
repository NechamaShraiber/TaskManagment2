using BOL.validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2), MaxLength(15)]
        public string Name { get; set; }
        [Required]
        [MinLength(2), MaxLength(10)]
        [UniqeUserName]
        public string UserName { get; set; }
        [Required]
        [MinLength(6), MaxLength(10)]
        public string Password { get; set; }
        [ForeignKey("job")]
        public int JobId { get; set; }
        [Required]
        [MinLength(6), MaxLength(30)]
        public string EMail { get; set; }
        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }

        //public  Job Job { get; set; }
        //public Worker Manager { get; set; }
    }
}
