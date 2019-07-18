using System;
using System.Collections.Generic;

namespace EdVision.Models
{
    public partial class University {
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual Address Address { get; set; }
        public double FederalRating { get; set; }

        public virtual ICollection<Department> Departments { get; set; }

        public double MeanGrants { get; set; }
        public double? HostelPrice { get; set; }

        public University() {
            Departments = new HashSet<Department>();
        }
    }
}
