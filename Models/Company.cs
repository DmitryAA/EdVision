using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.WebApi.Model
{
    public class Company {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string LegalName { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public double Rating { get; set; }

        // TODO: Rename
        public string INN { get; set; }
        public string ORGN { get; set; }

        public int CompanyId { get; set; }
        public ICollection<Mentor> Mentors { get; set; }
    }
}
