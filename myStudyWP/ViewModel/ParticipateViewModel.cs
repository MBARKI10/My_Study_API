using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myStudyWP.Models;

namespace myStudyWP.ViewModel
{
    class ParticipateViewModel
    {
        public ObservableCollection<Participate> ParticipateCollectionItems { get; set; }

    public ParticipateViewModel()
        {
            ParticipateCollectionItems = new ObservableCollection<Participate>();
        }

    public void InsertParticipates(ICollection<Participate> Participates, double width)
        {
            ParticipateCollectionItems.Clear();

            foreach (Participate participate in Participates)
            {
                participate.itemWidth = width;
                ParticipateCollectionItems.Add(participate);
            }
        }
    public void InsertParticipate(Participate participate)
    {
        ParticipateCollectionItems.Add(participate);
    }
    }
}
