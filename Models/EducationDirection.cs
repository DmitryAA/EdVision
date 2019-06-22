using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.WebApi.Model
{
    public class EducationDirection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        //public ICollection<DepartmentToEducationDirectionMapping> Mappings { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Student> Students { get; set; }

        //[NotMapped]
        public ICollection<Department> Departments { get; set; }
    }
}
