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
    public class Upsession
    {
        [DataMember]
        [Key]
        public int IdUpsession { get; set; }

        [DataMember]
        [Required]
        public String Author { get; set; }

        [DataMember]
        [Required]
        public DateTime PublishDate { get; set; }

        [DataMember]
        [Required]
        public DateTime DeadlineDate { get; set; }

        [DataMember]
        [Required]
        public String Session { get; set; }

        [DataMember]
        [Required]
        public int IdHour { get; set; }
        public virtual Hour Hour { get; set; }

        [DataMember]
        [Required]
        public int IdUser { get; set; }
        public virtual User User { get; set; }
    }
}