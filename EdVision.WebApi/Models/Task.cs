using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.WebApi.Model
{
    public enum TaskStatus {
        Created = 0,
        InProgress = 1,
        Complete = 2,
        Approved = 3,
        Rejected = 4
    }

    public partial class Task {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TaskStatus Status { get; set; }
        public virtual Grade LecturerGrade { get; set; }
        public virtual Grade MentorGrade { get; set; }
        public virtual Student Performer { get; set; }
        public virtual Project Project { get; set; }
    }
}
