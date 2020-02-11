using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myStudyWP.Models;

namespace myStudyWP.ViewModel
{
    class EventViewModel
    {
        public ObservableCollection<Event> EventCollectionItems { get; set; }

        public EventViewModel()
        {
            EventCollectionItems = new ObservableCollection<Event>();
        }
        
        public void InsertEvents(List<Event> Events, double width)
        {
            EventCollectionItems.Clear();

            foreach (Event _event in Events)
            {
                _event.itemWidth = width;
                EventCollectionItems.Add(_event);
            }
        }
    }
}
