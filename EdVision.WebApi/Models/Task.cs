using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.WebApi.Model
{
    public enum TaskStatus {
        Created,
        InProgress,
        Complete,
        Approved,
        Rejected
    }

    public partial class Task {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public virtual Grade LecturerGrade { get; set; }
        public virtual Grade MentorGrade { get; set; }
        public virtual Student Performer { get; set; }
        public virtual Project Project { get; set; }
    }
}
