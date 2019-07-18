using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.Models
{
    public partial class Grade {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }
        public virtual Person GradingPerson { get; set; }
    }
}
