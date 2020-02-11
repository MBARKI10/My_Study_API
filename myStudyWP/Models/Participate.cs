using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.Models
{
    public class Participate
    {
        public int IdParticipate { get; set; }
        public string Author { get; set; }

        public int IdUser { get; set; }

        public int IdEvent { get; set; }

        public double itemWidth { get; set; }
    }
}
