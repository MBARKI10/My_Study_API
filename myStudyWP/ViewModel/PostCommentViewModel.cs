using myStudyWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.ViewModel
{
    class PostCommentViewModel
    {
        public ObservableCollection<PostComment> CommentCollectionItems { get; set; }

        public PostCommentViewModel()
        {
            CommentCollectionItems = new ObservableCollection<PostComment>();
        }

        public void InsertComments(ICollection<PostComment> Comments, double width)
        {
            CommentCollectionItems.Clear();

            foreach (PostComment comment in Comments)
            {
                comment.itemWidth = width;
                CommentCollectionItems.Add(comment);
            }
        }

        public void InsertComment(PostComment comment)
        {
                CommentCollectionItems.Add(comment);
        }
        public void DeleteComment(PostComment comment)
        {
            CommentCollectionItems.Remove(comment);
            
        }
    }
}
