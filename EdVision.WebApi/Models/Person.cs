using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.WebApi.Model
{
    public partial class Person {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronimicName { get; set; }
        public virtual Address Address { get; set; }
        public DateTime Birthday { get; set; }
    }

    public partial class Mentor : Person {
        public virtual Company Company { get; set; }
        public string JobTitle { get; set; }
    }

    public partial class Student : Person {
        public Student() {
            Tasks = new HashSet<Task>();
            ProjectResults = new HashSet<CourseResult>();
        }
        public virtual Department Department { get; set; }
        public virtual EducationDirection Direction { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<CourseResult> ProjectResults { get; set; }
    }

    public class Lecturer: Person {
        public string AcademicDegree { get; set; }
        public string AcademicTitle { get; set; }
    }
}
