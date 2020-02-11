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
    class EventCommentDataService
    {
        private const string BaseUrl = @"http://localhost:50296/api/EventComments/";
        public string ErrorMessage = "";

        public async Task<List<EventComment>> GetCommentsAsync()
        {
            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var CommentsList = JsonConvert.DeserializeObject<List<EventComment>>(jsonResponse);

            return CommentsList;
        }


        public async Task<EventComment> GetCommentAsync(int id)
        {

            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var comment = JsonConvert.DeserializeObject<EventComment>(jsonResponse);

            return comment;
        }

        public async Task<bool> AddCommentAsync(EventComment comment)
        {
            var httpClient = new HttpClient();

            var jsonEmployee = JsonConvert.SerializeObject(comment);

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

        public async Task<bool> DeleteCommentAsync(int id)
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

        public async void getAllComments(Event _event,double width)
        {
            List<EventComment> ListComments = await GetCommentsAsync();
            List<EventComment> Comments = new List<EventComment>();
            foreach(EventComment comment in ListComments)
            {
                if (comment.IdEvent == _event.IdEvent)
                    Comments.Add(comment);
            }
           ViewModel.Statique._EventCommentViewModel.InsertComments(Comments, width);
        }
        public async Task EditCommentAsync(EventComment comment)
        {
            var httpClient = new HttpClient();

            var jsonEmployee = JsonConvert.SerializeObject(comment);

            var httpContent = new StringContent(jsonEmployee);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PutAsync(BaseUrl + comment.IdComment, httpContent);
        }
    }

}
