using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyStudyAPI.Models
{
    [DataContract]
    [Serializable]
    public class Hour
    {
        public Hour()
        {
            UpSessions = new List<Upsession>();
            Todos = new List<Todo>();
        }
        [DataMember]
        [Key]
        public int IdHour { get; set; }
        [DataMember]
        public String Time { get; set; }
        [DataMember]
        public String Teacher { get; set; }
        [DataMember]
        public String Subject { get; set; }
        [DataMember]
        public String Room { get; set; }
        [DataMember]
        public  int IdDay { get; set; }


        public virtual Day Day { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }
        public virtual ICollection<Upsession> UpSessions { get; set; } 
    }
}