using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.Models
{
    public class JobStatistics
    {
        public int Id { get; set; } 
        public int Year { get; set; }
        public int GotJoStudentNumbers { get; set; }
        public int TotalStudentNumber { get; set; }
    }
}
