using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myStudyWP.Models;
using myStudyWP.ViewModel;

namespace myStudyWP.Services
{
    class TodayDataService
    {
        TodoDataService tododata = new TodoDataService();
        EventDataService eventdata = new EventDataService();

        public async Task update(double width)
        {
            List<Todo> listtodo = new List<Todo>();
            List<Todo> ListTodo = new List<Todo>();
            listtodo = await tododata.GetTodosAsync();
            foreach(Todo todo in listtodo)
            {
                if (todo.DeadlineDate == DateTime.Today.Date && !tododata.iDone(todo))
                {
                    ListTodo.Add(todo);
                }
                    
            }
            Statique._TodayViewModel.InsertTodos(ListTodo, width);
            List<Event> listevent = new List<Event>();
            List<Event> ListEvent = new List<Event>();
            listevent = await eventdata.GetEventsAsync();
            foreach(Event _event in listevent)
            {
                if(_event.DeadlineDate == DateTime.Today.Date && eventdata.iParticipate(_event))
                {
                    ListEvent.Add(_event);
                }
            }
            Statique._TodayViewModel.InsertEvents(ListEvent, width);
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
            {

                Statique._TodayViewModel.HourCollectionItems = Statique._ClasseViewModel.HoursMonday;
            }
            if (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
            {

                Statique._TodayViewModel.HourCollectionItems = Statique._ClasseViewModel.HoursTuesday;
            }
            if (DateTime.Today.DayOfWeek == DayOfWeek.Wednesday)
            {

                Statique._TodayViewModel.HourCollectionItems = Statique._ClasseViewModel.HoursWednesday;
            }
            if (DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
            {

                Statique._TodayViewModel.HourCollectionItems = Statique._ClasseViewModel.HoursThursday;
            }
            if (DateTime.Today.DayOfWeek == DayOfWeek.Friday)
            {

                Statique._TodayViewModel.HourCollectionItems = Statique._ClasseViewModel.HoursFriday;
            }
            if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
            {

                Statique._TodayViewModel.HourCollectionItems = Statique._ClasseViewModel.HoursSaturday;
            }
            
            
        }
    }
}
