using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.Models
{
    public class PostComment
    {
        public int IdComment { get; set; }

        public String Author { get; set; }

        public DateTime PublishDate { get; set; }

        public String Content { get; set; }

        public int IdPost { get; set; }

        public int IdUser { get; set; }

        public double itemWidth { get; set; }
    }
}
