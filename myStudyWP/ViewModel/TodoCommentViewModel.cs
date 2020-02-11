using myStudyWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.ViewModel
{
    class TodoCommentViewModel
    {
        public ObservableCollection<TodoComment> CommentCollectionItems { get; set; }

        public TodoCommentViewModel()
        {
            CommentCollectionItems = new ObservableCollection<TodoComment>();
        }

        public void InsertComments(ICollection<TodoComment> Comments, double width)
        {
            CommentCollectionItems.Clear();

            foreach (TodoComment comment in Comments)
            {
                comment.itemWidth = width;
                CommentCollectionItems.Add(comment);
            }
        }

        public void InsertComment(TodoComment comment)
        {
                CommentCollectionItems.Add(comment);
        }
    }
}
