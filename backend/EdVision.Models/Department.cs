using System;
using System.Collections.Generic;

namespace EdVision.Models
{
    public partial class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public virtual ICollection<JobStatistics> Statistics { get; set; }
        public virtual ICollection<EducationDirection> Directions { get; set; }

        public int UniversityId { get; set; }

        public Department() {
            Statistics = new HashSet<JobStatistics>();
            Directions = new HashSet<EducationDirection>();
        }
    }
}
