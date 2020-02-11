using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.Models
{
    public class EventComment
    {
        public int IdComment { get; set; }

        public string Author { get; set; }

        public DateTime PublishDate { get; set; }

        public string Content { get; set; }

        public int IdEvent { get; set; }

        public int IdUser { get; set; }

        public double itemWidth { get; set; }
    }
}
