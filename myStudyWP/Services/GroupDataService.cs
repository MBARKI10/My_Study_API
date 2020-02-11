using myStudyWP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.Services
{
    public class GroupDataService
    {
        private const string BaseUrl = @"http://localhost:50296/api/Subgroups";
        public string ErrorMessage = "";


        public async Task<List<Group>> GetGroups()
        {
            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var groupList = JsonConvert.DeserializeObject<List<Group>>(jsonResponse);

            return groupList;
        }

        public async Task<List<Day>> GetDays()
        {
            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync("http://localhost:50296/api/Days");

            var dayList = JsonConvert.DeserializeObject<List<Day>>(jsonResponse);

            return dayList;
        }

        public async Task<List<Hour>> GetHours()
        {
            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync("http://localhost:50296/api/Hours");

            var hourList = JsonConvert.DeserializeObject<List<Hour>>(jsonResponse);

            return hourList;
        }


        public async Task<List<string>> GetGroupsLabel()
        {
            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync("http://localhost:50296/api/GroupsLabels");

            var labelList = JsonConvert.DeserializeObject<List<string>>(jsonResponse);

            return labelList;
        }


        public async void getMyClasse(string label, double width)
        {
            List<Group> ListGroups = await GetGroups();

            Group myGroup = new Group();

            foreach (Group group in ListGroups)
            {
                if (group.Label.Equals(label))
                {
                    myGroup.IdSubgroup = group.IdSubgroup;
                    myGroup.Label = group.Label;
                }
            }

            List<Day> ListDay = await GetDays();

            foreach (Day day in ListDay)
            {
                if (day.IdSubgroup == myGroup.IdSubgroup)
                {
                    myGroup.Days.Add(day);
                }
            }

            List<Hour> ListHour = await GetHours();

            foreach (Day day in myGroup.Days)
            {
                foreach (Hour hour in ListHour)
                {
                    if (hour.IdDay == day.IdDay)
                    {
                        day.Hours.Add(hour);
                    }
                }
            }

            ViewModel.Statique._ClasseViewModel.InsertGroup(myGroup, width);

        }

    }
}
