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
    public class Event
    {
        
        public Event()
        {
            Comments = new List<EventComment>();
            Joined = new List<Participate>();
        }
        [DataMember]
        [Key]
        public int IdEvent { get; set; }

        [DataMember]
        [Required]
        public String Author { get; set; }

        [DataMember]
        [Required]
        public String Club { get; set; }

        [DataMember]
        [Required]
        public DateTime PublishDate { get; set; }

        [DataMember]
        [Required]
        public DateTime DeadlineDate { get; set; }

        [DataMember]
        [Required]
        public String Title { get; set; }

        [DataMember]
        [Required]
        public String Description { get; set; }

        [DataMember]
        [Required]
        public int IdUser { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<EventComment> Comments { get; set; }

        public virtual ICollection<Participate> Joined { get; set; } 

    }
}