using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.Models
{
    public class Post
    {
        public Post()
        {
            Likes = new List<Like>();
            Comments = new List<PostComment>();
            Reports = new List<Report>();
        }

        public int IdPost { get; set; }

        public String Title { get; set; }

        public String Author { get; set; }

        public DateTime PublishDate { get; set; }

        public String Description { get; set; }

        public int IdUser { get; set; }

        public int IdSubgroup { get; set; }

        public double itemWidth { get; set; }

        public virtual List<Like> Likes { get; set; }

        public virtual List<PostComment> Comments { get; set; }

        public virtual List<Report> Reports { get; set; }
    }
}
