using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.WebApi.Model
{
    public class CourseResult {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Student Performer { get; set; }

        public Project EstimatedProject { get; set; }
        public Grade LecturerGrade { get; set; }
        public Grade MentorGrade { get; set; }
}
}
