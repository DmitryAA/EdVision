using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EdVision.Models
{
    public class DepartmentToEducationDirectionMapping
    {
        public int DepartmentId { get; set; }
        public int EducationDirectionId { get; set; }

        public Department Department { get; set; }
        public EducationDirection Direction { get; set; }
    }
}
