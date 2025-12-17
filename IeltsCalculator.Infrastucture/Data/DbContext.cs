using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IletsCalculator.Domain.Models;

namespace IeltsCalculator.Infrastucture.Data
{
    public class DbContext
    {
        public DbContext()
        {
            this.Ieltses = new Ielts[10];
        }

        public Ielts[] Ieltses { get; set; }
    }
}
