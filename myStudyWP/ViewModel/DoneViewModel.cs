using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myStudyWP.Models;

namespace myStudyWP.ViewModel
{
    class DoneViewModel
    {
        public ObservableCollection<Done> DoneCollectionItems { get; set; }

    public DoneViewModel()
        {
            DoneCollectionItems = new ObservableCollection<Done>();
        }

    public void InsertDones(ICollection<Done> Dones, double width)
        {
            DoneCollectionItems.Clear();

            foreach (Done done in Dones)
            {
                done.itemWidth = width;
                DoneCollectionItems.Add(done);
            }
        }

    public void InsertDone(Done done)
    {
        DoneCollectionItems.Add(done);
    }
    }
}
