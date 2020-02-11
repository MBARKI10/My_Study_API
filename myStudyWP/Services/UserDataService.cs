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
    public class UserDataService
    {
        private const string BaseUrl = @"http://localhost:50296/api/Users/";
        public string ErrorMessage = "";

        public async Task<List<User>> GetUsersAsync()
        {
            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var usersList = JsonConvert.DeserializeObject<List<User>>(jsonResponse);

            return usersList;
        }


        public async Task<bool> AddUserAsync(User user)
        {
            var listUsers = await GetUsersAsync();

            foreach (User item in listUsers)
            {
                if (item.Username == user.Username)
                {
                    ErrorMessage = "Username is already exist.";
                    return false;
                }
            }

            var httpClient = new HttpClient();

            var jsonUser = JsonConvert.SerializeObject(user);

            HttpContent httpContent = new StringContent(jsonUser);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PostAsync(new Uri(BaseUrl), httpContent);

            if (! response.IsSuccessStatusCode)
            {
                ErrorMessage = response.ReasonPhrase.ToString();
                return false;
            }

            return true;
        }


        public async Task EditUserAsync(User user)
        {
            var httpClient = new HttpClient();

            var jsonEmployee = JsonConvert.SerializeObject(user);

            var httpContent = new StringContent(jsonEmployee);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PutAsync(BaseUrl + user.IdUser, httpContent);
        }


        public async Task<User> UserLogin(string username, string password)
        {
            User loggedUser = null;
            var listUsers = await GetUsersAsync();
            foreach (User item in listUsers)
            {
                if (item.Username == username && item.Password == password)
                {
                    return loggedUser = item;
                }
            }

            return loggedUser;
        }


    }
}
