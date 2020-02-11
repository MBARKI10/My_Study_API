using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Linq;

namespace MyStudyAPI.Models
{
    [DataContract]
    [Serializable]
    public class Post
    {
        public Post()
        {
            Likes = new List<Like>();
            Comments = new List<PostComment>();
            Reports = new List<Report>();
        }
        [DataMember]
        [Key]
        public int IdPost { get; set; }
        [DataMember]
        public String Title { get; set; }
        [DataMember]
        [Required]
        public String Author { get; set; }
        [DataMember]

        [Required]
        public DateTime PublishDate { get; set; }
        [DataMember]
        [Required]
        public String Description { get; set; }
        [DataMember]
        public  int IdUser { get; set; }

        public virtual User User { get; set; }
        [DataMember]
        public int IdSubgroup { get; set; }

        public virtual Subgroup Subgroup { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Report> Reports { get; set; }

        public virtual ICollection<PostComment> Comments { get; set; }
    }

    


}