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
    class DoneDataService
    {
        private const string BaseUrl = @"http://localhost:50296/api/Dones/";
        public string ErrorMessage = "";

        public async Task<List<Done>> GetDonesAsync()
        {
            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var DoneList = JsonConvert.DeserializeObject<List<Done>>(jsonResponse);

            return DoneList;
        }


        public async Task<Done> GetDoneAsync(int id)
        {

            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var done = JsonConvert.DeserializeObject<Done>(jsonResponse);

            return done;
        }

        public async Task<bool> AddDoneAsync(Done done)
        {
            var httpClient = new HttpClient();

            var jsonEmployee = JsonConvert.SerializeObject(done);

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

        public async Task<bool> DeleteDoneAsync(int id)
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

        public async void getAllDones(Todo todo, double width)
        {
            List<Done> ListDones = await GetDonesAsync();
            List<Done> dones = new List<Done>();
            foreach (Done done in ListDones)
            {
                if (done.IdTodo == todo.IdTodo)
                    dones.Add(done);
            }
            ViewModel.Statique._DoneViewModel.InsertDones(dones, width);
        }
    }

}
