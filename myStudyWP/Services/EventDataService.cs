using myStudyWP.Models;
using myStudyWP.ViewModel;
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
    class EventDataService
    {
        private const string BaseUrl = @"http://localhost:50296/api/Events/";
        public string ErrorMessage = "";
        EventCommentDataService commentsData = new EventCommentDataService();
        ParticipateDataService participateData = new ParticipateDataService(); 
        public async Task<List<Event>> GetEventsAsync()
        {
            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var eventsList = JsonConvert.DeserializeObject<List<Event>>(jsonResponse);

            return eventsList;
        }


        public async Task<Event> GetEventAsync(int id)
        {

            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var _event = JsonConvert.DeserializeObject<Event>(jsonResponse);

            return _event;
        }

        public async Task<bool> AddEventAsync(Event _event)
        {
            var httpClient = new HttpClient();

            var jsonEmployee = JsonConvert.SerializeObject(_event);

            HttpContent httpContent = new StringContent(jsonEmployee);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PostAsync(new Uri(BaseUrl), httpContent);

            if (!response.IsSuccessStatusCode)
            {
                ErrorMessage = response.ReasonPhrase.ToString();
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteEventAsync(int id)
        {

            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(BaseUrl + id);

            if (!response.IsSuccessStatusCode)
            {
                ErrorMessage = response.ReasonPhrase.ToString();
                return false;
            }

            return true;
        }


        public async void getAllEvents(double width)
        {
            List<Event> ListEvents = await GetEventsAsync();

            List<EventComment> listComments = await commentsData.GetCommentsAsync();
            List<Participate> listParticipates = await participateData.GetParticipatesAsync();

            List<Event> lsFinal = AddCredsToEvents(ListEvents, listComments, listParticipates);

            ViewModel.Statique._EventViewModel.InsertEvents(lsFinal, width);
        }

        private List<Event> AddCredsToEvents(List<Event> ListEvents, List<EventComment> listComments, List<Participate> listParticipates)
        {
            foreach (Event _event in ListEvents)
            {
                foreach (EventComment comment in listComments)
                {
                    if (_event.IdEvent.Equals(comment.IdEvent))
                    {
                        _event.Comments.Add(comment);
                    }
                }

                foreach (Participate participate in listParticipates)
                {
                    if (_event.IdEvent.Equals(participate.IdEvent))
                    {
                        _event.Participants.Add(participate);
                    }
                }
            }

            return ListEvents;
        }
        public bool iParticipate(Event _event)
        {
            List<Participate> participates = _event.Participants.ToList();
            foreach (Participate participate in participates)
            {
                if (participate.IdUser == Statique._LoggedUser.IdUser)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<Event> getevent(Event _event, double width)
        {
            List<EventComment> listComments = await commentsData.GetCommentsAsync();
            List<Participate> listParticipates = await participateData.GetParticipatesAsync();
            return AddCredsToEvent(_event, listComments, listParticipates, width);

        }
        public async Task EditEventAsync(Event _event)
        {
            var httpClient = new HttpClient();

            var jsonEmployee = JsonConvert.SerializeObject(_event);

            var httpContent = new StringContent(jsonEmployee);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PutAsync(BaseUrl + _event.IdEvent, httpContent);
        }
        public Event AddCredsToEvent(Event _event, List<EventComment> listComments, List<Participate> listParticipates, double width)
        {
            _event.Comments.Clear();
            _event.Participants.Clear();
            foreach (EventComment comment in listComments)
            {
                if (_event.IdEvent.Equals(comment.IdEvent))
                {
                    _event.Comments.Add(comment);
                }
            }
            Statique._EventCommentViewModel.InsertComments(_event.Comments, width);

            foreach (Participate participate in listParticipates)
            {
                if (_event.IdEvent.Equals(participate.IdEvent))
                {
                    _event.Participants.Add(participate);
                }
            }
            Statique._ParticipateViewModel.InsertParticipates(_event.Participants, width);
            return _event;
        }
    }
}
