﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyStudyAPI.Models
{
    [DataContract]
    [Serializable]
    public class Like
    {
        [Required]
        [DataMember]
        public int IdLike { get; set; }
        [Required]
        [DataMember]
        public  int IdUser { get; set; }
        public virtual User User { get; set; }
        [Required]
        [DataMember]
        public  int IdPost { get; set; }
        public virtual Post Post { get; set; }
    }
}