using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.Models
{
    public class Todo
    {
        public Todo()
        {
            Comments = new List<TodoComment>();
            Dones = new List<Done>();
        }
        public int IdTodo { get; set; }

        public string Author { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime DeadlineDate { get; set; }

        public string Content { get; set; }

        public int IdHour { get; set; }

        public int IdUser { get; set; }

        public double itemWidth { get; set; }

        public virtual ICollection<TodoComment> Comments { get; set; }
        public virtual ICollection<Done> Dones { get; set; }
    }
}
