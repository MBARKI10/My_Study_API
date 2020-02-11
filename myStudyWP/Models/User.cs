using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.Models
{
    public class User
    {
        public User()
        {
            Posts = new List<Post>();
            Likes  = new List<Like>();
            PostComments = new List<PostComment>();
            TodoComments = new List<TodoComment>();
            EventComments = new List<EventComment>();
            Dones = new List<Done>();
            Participants = new List<Participate>();
            Todos = new List<Todo>();
            Events = new List<Event>();
            Upsessions = new List<Upsession>();
            Reports = new List<Report>();

        }

        public int IdUser { get; set; }

        public string Username { get; set; }

        public string Fullname { get; set; }

        public string Password { get; set; }

        public string Classe { get; set; }

        public int IdSubgroup { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<PostComment> PostComments { get; set; }

        public virtual ICollection<TodoComment> TodoComments { get; set; }

        public virtual ICollection<EventComment> EventComments { get; set; }

        public virtual ICollection<Done> Dones { get; set; }

        public virtual ICollection<Participate> Participants { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<Upsession> Upsessions { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
