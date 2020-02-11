using myStudyWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace myStudyWP.Services
{
    class LikeDataService
    {
        private const string BaseUrl = @"http://localhost:50296/api/Likes/";
        public string ErrorMessage = "";

        public async Task<List<Like>> GetLikesAsync()
        {
            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var LikeList = JsonConvert.DeserializeObject<List<Like>>(jsonResponse);

            return LikeList;
        }


        public async Task<Like> GetLikeAsync(int id)
        {

            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var like = JsonConvert.DeserializeObject<Like>(jsonResponse);

            return like;
        }

        public async Task<bool> AddLikeAsync(Like like)
        {
            var httpClient = new HttpClient();

            var jsonEmployee = JsonConvert.SerializeObject(like);

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
        public async Task<bool> DeleteLikeAsync(string id)
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

        public async void getAllLikes(Post post, double width)
        {
            List<Like> ListLikes = await GetLikesAsync();
            List<Like> likes = new List<Like>();
            foreach (Like like in ListLikes)
            {
                if (like.IdPost == post.IdPost)
                    likes.Add(like);
            }
            ViewModel.Statique._LikeViewModel.InsertLikes(likes, width);
        }
    }

}
