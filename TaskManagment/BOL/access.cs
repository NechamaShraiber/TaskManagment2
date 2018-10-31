using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class Access
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2), MaxLength(15)]
        public string Name { get; set; }
    }
}
