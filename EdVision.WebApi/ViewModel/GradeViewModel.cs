using EdVision.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdVision.WebApi.ViewModel
{
    public class GradeViewModel {

        public class TaskViewModel {
            public TaskViewModel(Task src) {
                Id = src.Id;
                Name = src.Name;
                StartDate = src.StartDate;
                EndDate = src.EndDate;
                Status = src.Status;
                LecturerGrade = new GradeViewModel(src.LecturerGrade);
                MentorGrade = new GradeViewModel(src.MentorGrade);
                Performer = new PersonViewModel(src.Performer);
                Project = new TaskProjectViewModel(src.Project);
            }
            public int Id { get; }
            public string Name { get; }
            public DateTime StartDate { get; }
            public DateTime? EndDate { get; }
            public TaskStatus Status { get; }
            public virtual GradeViewModel LecturerGrade { get; }
            public virtual GradeViewModel MentorGrade { get; }
            public virtual PersonViewModel Performer { get; }
            public TaskProjectViewModel Project { get; }
        }

        public class TaskProjectViewModel {
            public TaskProjectViewModel(Project src) {
                Id = src.Id;
                Name = src.Name;
                Description = src.Description;
                Comment = src.Comment;
                StartDate = src.StartDate;
                EndDate = src.EndDate;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Comment { get; set; }

            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }       
        }

        public GradeViewModel(Grade src) {
            Id = src.Id;
            Value = src.Value;
            Comment = src.Comment;
            GradingPerson = new PersonViewModel(src.GradingPerson);
        }

        public int Id { get; }
        public int Value { get; }
        public string Comment { get; }
        public virtual PersonViewModel GradingPerson { get; }
    }

    public class PersonViewModel
    {
        public PersonViewModel(Person src) {
            Id = src.Id;
            FirstName = src.FirstName;
            LastName = src.LastName;
            PatronimicName = src.PatronimicName;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string PatronimicName { get; }
    }
}