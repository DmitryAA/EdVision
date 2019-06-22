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

    public class Task {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public Grade LecturerGrade { get; set; }
        public Grade MentorGrade { get; set; }
        public Student Performer { get; set; }
        public Project Project { get; set; }
    }
}
