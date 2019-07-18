using System;
using System.Collections.Generic;

namespace EdVision.Models
{ 
    public enum ProjectType
    {
        LaboratoryWork,
        ClassProject,
        CompanyCase,
        DiplomaProject,
        BachelorDegreeProject,
        MasterDegreeProject
    }

    public enum ProjectCategory
    {
        Social,
        Commerce,
        Investigation,
        Required
    }

    public partial class Project {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Company Company { get; set; }
        public ProjectType Type {get; set;}
        public ProjectCategory Category { get; set; }
        public virtual ICollection<StudentTask> Tasks { get; set; }

        public Project() {
            Tasks = new HashSet<StudentTask>();
        }
    }
}
