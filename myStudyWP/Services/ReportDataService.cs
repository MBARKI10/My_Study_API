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
    class ReportDataService
    {
        private const string BaseUrl = @"http://localhost:50296/api/Reports/";
        public string ErrorMessage = "";

        public async Task<List<Report>> GetReportsAsync()
        {
            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var ReportList = JsonConvert.DeserializeObject<List<Report>>(jsonResponse);

            return ReportList;
        }


        public async Task<Report> GetReportAsync(int id)
        {

            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var Report = JsonConvert.DeserializeObject<Report>(jsonResponse);

            return Report;
        }

        public async Task<bool> AddReportAsync(Report report)
        {
            var httpClient = new HttpClient();

            var jsonEmployee = JsonConvert.SerializeObject(report);

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

        public async Task<bool> DeleteReportAsync(int id)
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

        public async void getAllReports(Post post, double width)
        {
            List<Report> ListReports = await GetReportsAsync();
            List<Report> Reports = new List<Report>();
            foreach (Report report in Reports)
            {
                if (report.IdPost == post.IdPost)
                    Reports.Add(report);
            }
            ViewModel.Statique._sViewModel.InsertReports(Reports, width);
        }
    }

}
