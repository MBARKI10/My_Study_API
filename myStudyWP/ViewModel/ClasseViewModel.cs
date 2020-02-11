using myStudyWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.ViewModel
{
    public class ClasseViewModel
    {
        public ObservableCollection<Hour> HoursMonday { get; set; }
        public ObservableCollection<Hour> HoursTuesday { get; set; }
        public ObservableCollection<Hour> HoursWednesday { get; set; }
        public ObservableCollection<Hour> HoursThursday { get; set; }
        public ObservableCollection<Hour> HoursFriday { get; set; }
        public ObservableCollection<Hour> HoursSaturday { get; set; }

        public ClasseViewModel()
        {
            HoursMonday = new ObservableCollection<Hour>();
            HoursTuesday = new ObservableCollection<Hour>();
            HoursWednesday = new ObservableCollection<Hour>();
            HoursThursday = new ObservableCollection<Hour>();
            HoursFriday = new ObservableCollection<Hour>();
            HoursSaturday = new ObservableCollection<Hour>();
        }

        public void InsertGroup(Group group, double width)
        {
            foreach (Day day in group.Days)
            {
                if (day.Hours.Count != 0)
                {
                    switch (day.Label)
                    {
                        case "Lundi": insertHour(day, HoursMonday, width); break;
                        case "Mardi": insertHour(day, HoursTuesday, width); break;
                        case "Mercredi": insertHour(day, HoursWednesday, width); break;
                        case "Jeudi": insertHour(day, HoursThursday, width); break;
                        case "Vendredi": insertHour(day, HoursFriday, width); break;
                        case "Samedi": insertHour(day, HoursSaturday, width); break;

                        default:
                            break;
                    }
                }
            }
        }

        private void insertHour(Day day, ObservableCollection<Hour> HoursCollection, double width)
        {
            foreach (Hour item in day.Hours)
            {
                item.itemWidth = width;
                HoursCollection.Add(item);
            }
        }
    }
}
