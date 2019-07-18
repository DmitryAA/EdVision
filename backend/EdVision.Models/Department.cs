using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EdVision.Models
{
    public partial class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public virtual ICollection<JobStatitics> Statitics { get; set; }
        public virtual ICollection<EducationDirection> Directions { get; set; }

        public Department() {
            Statitics = new HashSet<JobStatitics>();
            Directions = new HashSet<EducationDirection>();
        }
    }
}
