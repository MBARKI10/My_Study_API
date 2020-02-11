using myStudyWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.ViewModel
{
    class PostViewModel
    {

        public ObservableCollection<Post> postCollectionItems { get; set; }

        public PostViewModel()
        {
            postCollectionItems = new ObservableCollection<Post>();
        }

        public void InsertPosts(List<Post> posts, double width)
        {
            postCollectionItems.Clear();
           
            foreach (Post post in posts)
            {
                post.itemWidth = width;
                postCollectionItems.Add(post);
            }
           
        }
    }
}
