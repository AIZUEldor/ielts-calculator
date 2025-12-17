using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IletsCalculator.Domain.Models
{
    public class Ielts
    {
        public string fullName { get; set; }
        public double listening { get; set; }
        public double reading { get; set; }
        public double writing { get; set; }
        public double speaking { get; set; }
        public double overall { get; set; }

    }
}
