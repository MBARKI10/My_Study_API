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
    class TodoCommentDataService
    {
        private const string BaseUrl = @"http://localhost:50296/api/TodoComments/";
        public string ErrorMessage = "";

        public async Task<List<TodoComment>> GetCommentsAsync()
        {
            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var CommentsList = JsonConvert.DeserializeObject<List<TodoComment>>(jsonResponse);

            return CommentsList;
        }


        public async Task<TodoComment> GetCommentAsync(int id)
        {

            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var comment = JsonConvert.DeserializeObject<TodoComment>(jsonResponse);

            return comment;
        }

        public async Task<bool> AddCommentAsync(TodoComment comment)
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

        public async void getAllComments(Todo todo,double width)
        {
            List<TodoComment> ListComments = await GetCommentsAsync();
            List<TodoComment> Comments = new List<TodoComment>();
            foreach(TodoComment comment in ListComments)
            {
                if (comment.IdTodo == todo.IdTodo)
                    Comments.Add(comment);
            }
           ViewModel.Statique._TodoCommentViewModel.InsertComments(Comments, width);
        }
        public async Task EditCommentAsync(TodoComment comment)
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
