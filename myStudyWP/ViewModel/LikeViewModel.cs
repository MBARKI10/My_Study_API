using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myStudyWP.Models;

namespace myStudyWP.ViewModel
{
    class LikeViewModel
    {
        public ObservableCollection<Like> LikeCollectionItems { get; set; }

    public LikeViewModel()
        {
            LikeCollectionItems = new ObservableCollection<Like>();
        }

    public void InsertLikes(ICollection<Like> Likes, double width)
        {
            LikeCollectionItems.Clear();

            foreach (Like like in Likes)
            {
                like.itemWidth = width;
                LikeCollectionItems.Add(like);
            }
        }
        public void InsertLike(Like like)
    {
        LikeCollectionItems.Add(like);
    }
    }
}
