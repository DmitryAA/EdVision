﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.WebApi.Model
{ 
    public enum ProjectType
    {
        LaboratotyWork,
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

    public class Project {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Department Department { get; set; }
        public EducationDirection Direction { get; set; }
        public Company Company { get; set; }
        public ProjectType Type {get; set;}
        public ProjectCategory Category { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}