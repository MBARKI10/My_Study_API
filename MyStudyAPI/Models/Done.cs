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
    public class Done
    {
        [Required]
        [DataMember]
        public int IdDone { get; set; }
        [Required]
        [DataMember]
        public int IdUser { get; set; }
        public virtual User User { get; set; }

        [Required]
        [DataMember]
        public int IdTodo { get; set; }
        public virtual Todo Todo { get; set; }
    }
}