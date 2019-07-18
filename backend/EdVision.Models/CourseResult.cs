using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EdVision.Models
{
    public class CourseResult {
        public int Id { get; set; }
        public virtual Student Performer { get; set; }

        public virtual Project EstimatedProject { get; set; }
        public virtual Grade LecturerGrade { get; set; }
        public virtual Grade MentorGrade { get; set; }
}
}
