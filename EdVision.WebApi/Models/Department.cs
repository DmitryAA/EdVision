using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.WebApi.Model
{
    public partial class Department
    {
        public Department() {
            Projects = new HashSet<Project>();
            Students = new HashSet<Student>();
            Statitics = new HashSet<JobStatitics>();
            Directions = new HashSet<EducationDirection>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
       



        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Student> Students { get; set; } 
        public virtual ICollection<JobStatitics> Statitics { get; set; }

       
        public virtual ICollection<EducationDirection> Directions { get; set; }
    }
}
