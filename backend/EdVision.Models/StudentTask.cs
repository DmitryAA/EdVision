using System;

namespace EdVision.Models {
    public enum StudentTaskStatus {
        Created = 0,
        InProgress = 1,
        Complete = 2,
        Approved = 3,
        Rejected = 4
    }

    public partial class StudentTask {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public StudentTaskStatus Status { get; set; }
        public virtual Grade LecturerGrade { get; set; }
        public virtual Grade MentorGrade { get; set; }
        public int ProjectId { get; set; }
        
        //public virtual Student Performer { get; set; }
        //public virtual Project Project { get; set; }
    }
}
