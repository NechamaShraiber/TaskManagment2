using BOL.validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2), MaxLength(25)]
        [UniqeName]
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
     //   [RangeDate]
        [Required]
        public DateTime EndDate { get; set; }
    }
}
/*
 * 
 * 
השיחה נפתחה. הודעה אחת שלא נקראה

namespace BOL
{
    class Project
    {
       
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringValidator(MaxLength = 15, MinLength = 2)]
        [RegularExpression(@"[A-Za-z]+", ErrorMessage = "Project name can contain only letters")]
        public string ProjectName { get; set; }

        
        public int ManagerId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

       
        public int TeamLeaderId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "TotalHours must be above 0")]
        //customer validation totalHours=3 sum of department hours
        public int TotalHours { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Column(TypeName = "Date")]
        [DateGreaterThan]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Column(TypeName = "Date")]
        [DateGreaterThan]
        public DateTime EndDate { get; set; }

        //Navigation Properties

        public User Manager { get; set; }

        public Customer Customer { get; set; }

     
    [ForeignKey("Manager")]
        public List<DepartmentHours> DepartmentHours { get; set; }

        public List<WorkerHours> WorkersHours { get; set; }

        public List<PresenceHours> PresenceHours { get; set; }


    }
}


 */
