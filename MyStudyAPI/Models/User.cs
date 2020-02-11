using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyStudyAPI.Models
{
    [DataContract]
    [Serializable]
    public class User
    {

        public User()
        {
            Posts = new List<Post>();
            Likes = new List<Like>();
            PostComments = new List<PostComment>();
            EventComments = new List<EventComment>();
            TodoComments = new List<TodoComment>();
            Dones = new List<Done>();
            Joineds = new List<Participate>();
            Todos = new List<Todo>();
            Events = new List<Event>();
            Upsessions = new List<Upsession>();
            Reports = new List<Report>();
        }

        [DataMember]
        [Key]
        public int IdUser { get; set; }

        [DataMember]
        public String Username { get; set; }

        [DataMember]
        public String Fullname { get; set; }

        [DataMember]
        public String Password { get; set; }

        [DataMember]
        public String Classe { get; set; }
        [DataMember]
        public int IdSubgroup { get; set; }

        public virtual Subgroup Subgroup { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Done> Dones { get; set; }

        public virtual ICollection<Participate> Joineds { get; set; }

        public virtual ICollection<PostComment> PostComments { get; set; }

        public virtual ICollection<EventComment> EventComments { get; set; }

        public virtual ICollection<TodoComment> TodoComments { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<Upsession> Upsessions { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
