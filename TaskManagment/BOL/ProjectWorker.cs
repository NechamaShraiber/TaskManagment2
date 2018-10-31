using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{
  public  class ProjectWorker
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Workers")]
        public int WorkerId { get; set; }
        [ForeignKey("Projects")]
        public Project ProjectId { get; set; }

        public int AllocatedHours { get; set; }
      

        public List<Worker> Workers { get; set; }

        public List<Project> Projects { get; set; }
    }
}
