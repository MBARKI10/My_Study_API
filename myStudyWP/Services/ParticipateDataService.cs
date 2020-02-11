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
    class ParticipateDataService
    {
        private const string BaseUrl = @"http://localhost:50296/api/Participates/";
        public string ErrorMessage = "";

        public async Task<List<Participate>> GetParticipatesAsync()
        {
            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var ParticipateList = JsonConvert.DeserializeObject<List<Participate>>(jsonResponse);

            return ParticipateList;
        }


        public async Task<Participate> GetParticipateAsync(int id)
        {

            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var Participate = JsonConvert.DeserializeObject<Participate>(jsonResponse);

            return Participate;
        }

        public async Task<bool> AddParticipateAsync(Participate participate)
        {
            var httpClient = new HttpClient();

            var jsonEmployee = JsonConvert.SerializeObject(participate);

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

        public async Task<bool> DeleteParticipateAsync(int id)
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

        public async void getAllParticipate(Event _event, double width)
        {
            List<Participate> ListParticipate = await GetParticipatesAsync();
            List<Participate> participates = new List<Participate>();
            foreach (Participate participate in ListParticipate)
            {
                if (participate.IdEvent == _event.IdEvent)
                    participates.Add(participate);
            }
            ViewModel.Statique._ParticipateViewModel.InsertParticipates(participates, width);
        }
    }

}
