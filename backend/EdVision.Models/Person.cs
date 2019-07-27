using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.Models
{
    public partial class Person {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronimicName { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

        public Person() {
            Contacts = new HashSet<Contact>();
        }
    }

    public partial class Mentor : Person {
        //public virtual Company Company { get; set; }
        public string JobTitle { get; set; }
    }

    public partial class Student : Person {
        public Student() {
            Tasks = new HashSet<StudentTask>();
            ProjectResults = new HashSet<CourseResult>();
        }

        public virtual ICollection<StudentTask> Tasks { get; set; }
        public virtual ICollection<CourseResult> ProjectResults { get; set; }
    }

    public class Lecturer: Person {
        public string AcademicDegree { get; set; }
        public string AcademicTitle { get; set; }
    }
}
