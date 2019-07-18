using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdVision.Models
{
    public class Portfolio {
        public Student PersonInfo { get; set; }
        public University PersonUniversity { get; set; }
        public Department PersonDepartment { get; set; }
        public IList<StudentTask> ProjectTasks { get; set; }
        public double MenthorRating { get; set; }
        public double LecturerRating { get; set; }
    }

}