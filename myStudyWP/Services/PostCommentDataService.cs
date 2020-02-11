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
    class PostCommentDataService
    {
        private const string BaseUrl = @"http://localhost:50296/api/PostComments/";
        public string ErrorMessage = "";

        public async Task<List<PostComment>> GetCommentsAsync()
        {
            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var CommentsList = JsonConvert.DeserializeObject<List<PostComment>>(jsonResponse);

            return CommentsList;
        }


        public async Task<PostComment> GetCommentAsync(int id)
        {

            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var comment = JsonConvert.DeserializeObject<PostComment>(jsonResponse);

            return comment;
        }

        public async Task<bool> AddCommentAsync(PostComment comment)
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

        public async void getAllComments(Post post,double width)
        {
            List<PostComment> ListComments = await GetCommentsAsync();
            List<PostComment> Comments = new List<PostComment>();
            foreach (PostComment comment in ListComments)
            {
                if (comment.IdPost == post.IdPost)
                    Comments.Add(comment);
            }
            ViewModel.Statique._PostCommentViewModel.InsertComments(Comments, width);
        }


        public async Task EditCommentAsync(PostComment comment)
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
