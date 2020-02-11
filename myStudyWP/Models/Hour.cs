using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.Models
{
    public class Hour
    {
        public Hour()
        {
            Todos = new List<Todo>();
        }

        public int IdHour { get; set; }
        public double itemWidth { get; set; }
        public string Time { get; set; }
        public string Teacher { get; set; }
        public string Subject { get; set; }
        public string Room { get; set; }

        public int IdDay { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }
    }
}
