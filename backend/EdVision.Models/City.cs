using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EdVision.Models
{
    public partial class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Coordinates { get; set; }
        public double MeanIncome { get; set; }
        public double MeanExpenses { get; set; }
        public double HappinessIndex { get; set; }

        public virtual Region Region { get; set; }
    }
}
