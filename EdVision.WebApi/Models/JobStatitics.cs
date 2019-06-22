using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.WebApi.Model
{
    public class JobStatitics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public int Year { get; set; }
        public int GotJoStudentNumbers { get; set; }
        public int TotalStudentNumber { get; set; }

        public Department Department { get; set; }
    }
}
