using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyStudyAPI.Models
{
    [Serializable]
    [DataContract]
    public class Participate
    {
        [Required]
        [DataMember]
        public int IdParticipate { get; set; }
        [Required]
        [DataMember]
        public String Author { get; set; }

        [Required]
        [DataMember]
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        [Required]
        [DataMember]
        public int IdEvent { get; set; }
        public virtual Event Event { get; set; }
    }
}