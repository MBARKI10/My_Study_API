using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.Models
{
    public class Event
    {
        public Event()
        {
            Comments = new List<EventComment>();
            Participants = new List<Participate>();
        }
        public int IdEvent { get; set; }

        public string Author { get; set; }

        public string Club { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime DeadlineDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int IdUser { get; set; }

        public double itemWidth { get; set; }

        public ICollection<EventComment> Comments { get; set; }
        public ICollection<Participate> Participants { get; set; }
    }
}