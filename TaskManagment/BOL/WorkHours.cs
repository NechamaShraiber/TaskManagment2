using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{
    class WorkHours
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProjectWorks")]
        public int ProjectWorkId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        //public List<ProjectWorker> ProjectWorks { get; set; }
    }
}
