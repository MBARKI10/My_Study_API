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
    public class TodoComment
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
        public int IdTodo { get; set; }
        public virtual Todo Todo { get; set; }
        [DataMember]
        public int IdUser { get; set; }
        public virtual User User { get; set; }
    }
}