using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EdVision.Models
{
    public partial class EducationDirection
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public EducationDirection() {
            Projects = new HashSet<Project>();
            Students = new HashSet<Student>();
            //Departments = new HashSet<Department>();
        }

    }
}
