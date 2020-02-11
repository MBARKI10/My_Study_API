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
    class UpsessionDataService
    {
        private const string BaseUrl = @"http://localhost:50296/api/Upsessions/";
        public string ErrorMessage = "";

        public async Task<List<Upsession>> GetUpsessionsAsync()
        {
            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var upsessionsList = JsonConvert.DeserializeObject<List<Upsession>>(jsonResponse);

            return upsessionsList;
        }


        public async Task<Upsession> GetUpsessionAsync(int id)
        {

            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var upsession = JsonConvert.DeserializeObject<Upsession>(jsonResponse);

            return upsession;
        }

        public async Task<bool> AddUpsessionAsync(Upsession upsession)
        {
            var httpClient = new HttpClient();

            var jsonEmployee = JsonConvert.SerializeObject(upsession);

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

        public async Task<bool> DeleteUpsessionAsync(int id)
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
        public async void getAllUpsessions(Hour hour, double width)
        {
            List<Upsession> ListUpsessions = await GetUpsessionsAsync();
            List<Upsession> upsessions = new List<Upsession>();
            foreach (Upsession upsession in ListUpsessions)
            {
                if (upsession.IdHour == upsession.IdHour)
                    upsessions.Add(upsession);
            }
            ViewModel.Statique._UpsessionViewModel.InsertUpsessions(upsessions, width);
        }
    }
}
