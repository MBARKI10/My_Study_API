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
    public class PostComment
    {
        [Key]
        [DataMember]
        public int IdComment { get; set; }

        [Required]
        [DataMember]
        public String Author { get; set; }
        [Required]
        [DataMember]
        public DateTime PublishDate { get; set; }
        [Required]
        [DataMember]
        public String Content { get; set; }
        [DataMember]
        [Required]
        public  int IdPost { get; set; }
        public virtual Post Post { get; set; }
        [DataMember]
        [Required]
        public int IdUser { get; set; }
        public virtual User User { get; set; }
    }
}