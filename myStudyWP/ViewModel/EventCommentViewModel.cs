using myStudyWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.ViewModel
{
    class EventCommentViewModel
    {
        public ObservableCollection<EventComment> CommentCollectionItems { get; set; }

        public EventCommentViewModel()
        {
            CommentCollectionItems = new ObservableCollection<EventComment>();
        }

        public void InsertComments(ICollection<EventComment> Comments, double width)
        {
            CommentCollectionItems.Clear();

            foreach (EventComment comment in Comments)
            {
                comment.itemWidth = width;
                CommentCollectionItems.Add(comment);
            }
        }

        public void InsertComment(EventComment comment)
        {
                CommentCollectionItems.Add(comment);
        }
    }
}
