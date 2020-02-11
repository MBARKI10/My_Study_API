using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myStudyWP.Models;

namespace myStudyWP.ViewModel
{
    class TodayViewModel
    {
        public ObservableCollection<Todo> TodoCollectionItems { get; set; }
        public ObservableCollection<Hour> HourCollectionItems { get; set; }
        public ObservableCollection<Event> EventCollectionItems { get; set; }

        public TodayViewModel()
        {
            TodoCollectionItems = new ObservableCollection<Todo>();
           HourCollectionItems = new ObservableCollection<Hour>();
           EventCollectionItems = new ObservableCollection<Event>();
        }
       
        public void InsertTodos(ICollection<Todo> todos, double width)
        {
            TodoCollectionItems.Clear();

            foreach (Todo todo in todos)
            {
                todo.itemWidth = width;
                TodoCollectionItems.Add(todo);
            }
        }
        public void InsertEvents(ICollection<Event> Events, double width)
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
