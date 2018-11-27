using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{
  public  class ProjectWorker
    {
        [Key]
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public Project ProjectId { get; set; }

        public float AllocatedHours { get; set; }
      

       
    }
}
