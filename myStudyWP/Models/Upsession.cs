using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.Models
{
    public class Upsession
    {
        public int IdUpsession { get; set; }

        public string Author { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime DeadlineDate { get; set; }

        public string Session { get; set; }

        public int IdHour { get; set; }

        public int IdUser { get; set; }

        public double itemWidth { get; set; }
    }
}
