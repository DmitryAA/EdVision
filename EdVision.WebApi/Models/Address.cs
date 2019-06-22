using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.WebApi.Model
{
    public partial class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string AddressString { get; set; }
        public City City { get; set; }
        public string Coordinates { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Link { get; set; }
    }
}
