using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.WebApi.Model
{
    public class Person {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronimicName { get; set; }
        public Address Address { get; set; }
        public DateTime Birthday { get; set; }
    }

    public class Mentor : Person {
        public Company Company { get; set; }
        public string JobTitle { get; set; }
    }

    public class Student : Person {
        public Department Department { get; set; }
        public EducationDirection Direction { get; set; }

        public ICollection<Task> Tasks { get; set; }
        public ICollection<CourseResult> ProjectResults { get; set; }
    }

    public class Lecturer: Person {
        public string AcademicDegree { get; set; }
        public string AcademicTitle { get; set; }
    }
}
