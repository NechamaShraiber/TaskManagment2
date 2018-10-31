using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{
    public class AccessJob
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("jobs")]
        public int JobId { get; set; }
        [ForeignKey("AccessId")]
        public int AccessId { get; set; }
        //public List<Job> jobs { get; set; }
        //public List<Access> access { get; set; }
    }
}
