using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.WebApi.Model
{


    public partial class University {
        public University() {
            Departments = new HashSet<Department>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual Address Address { get; set; }
        public double FederalRating { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public double MeanGrants { get; set; }
        public double? HostelPrice { get; set; }


    } 
}
