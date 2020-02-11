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
    public class Day
    {
        public Day()
        {
            Hours = new List<Hour>();
        }
        [DataMember]
        [Key]
        public int IdDay { get; set; }
        [DataMember]
        [Required]
        public String Label { get; set; }
        [DataMember]
        public  int IdSubgroup { get; set; }

        public virtual Subgroup Subgroup { get; set; }

        public virtual ICollection<Hour> Hours { get; set; }
    }
}