using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EdVision.Models
{
    public partial class Company {
        public int Id { get; set; }

        public string Name { get; set; }
        public string LegalName { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }

        // TODO: Rename
        public string INN { get; set; }
        public string ORGN { get; set; }

        public virtual ICollection<Mentor> Mentors { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }

        public Company() {
            Mentors = new HashSet<Mentor>();
        }
    }
}
