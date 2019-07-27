using System;
using System.Collections.Generic;

namespace EdVision.Models
{
    public partial class University {
        public int Id { get; set; }

        public string Name { get; set; }
        public double FederalRating { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<EducationDirection> EducationDirections { get; set; }

        public double MeanGrants { get; set; }
        public double? HostelPrice { get; set; }

        public University() {
            Contacts = new HashSet<Contact>();
            Departments = new HashSet<Department>();
            EducationDirections = new HashSet<EducationDirection>();
        }
    }
}
