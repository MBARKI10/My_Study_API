using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.Models
{
    public class Group
    {
        public Group()
        {
            Posts = new List<Post>();
        }
        public int IdSubgroup { get; set; }
        public string Label { get; set; }

        public List<Day> Days = new List<Day>();
        public virtual ICollection<Post> Posts { get; set; }
    }
}
