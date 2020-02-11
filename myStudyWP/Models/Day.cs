using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.Models
{
    public class Day
    {
        public Day()
        {
            Hours = new List<Hour>();
        }
        public int IdDay { get; set; }

        public string Label { get; set; }

        public int IdSubgroup { get; set; }

        public ICollection<Hour> Hours { get; set; }
    }
}
