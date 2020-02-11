using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.Models
{
    public class Like
    {
        public int IdLike { get; set; }

        public int IdUser { get; set; }

        public int IdPost { get; set; }

        public double itemWidth { get; set; }
    }
}
