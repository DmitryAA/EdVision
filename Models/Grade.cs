using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.WebApi.Model
{
    public class Grade {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }
        public Person GradingPerson { get; set; }

        public Task TaskEstimatedByLecturer { get; set; }
        public Task TaskEstimatedByMentor { get; set; }
        public CourseResult ProjectResultEstimatedByLectuer { get; set; }
        public CourseResult ProjectResultEstimatedByMentor { get; set; }
    }
}
