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
    class TodoDataService
    {
        private const string BaseUrl = @"http://localhost:50296/api/Todos/";
        public string ErrorMessage = "";
        TodoCommentDataService commentsData = new TodoCommentDataService();
        DoneDataService doneData = new DoneDataService(); 
        public async Task<List<Todo>> GetTodosAsync()
        {
            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var todosList = JsonConvert.DeserializeObject<List<Todo>>(jsonResponse);

            return todosList;
        }


        public async Task<Todo> GetTodoAsync(int id)
        {

            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var todo = JsonConvert.DeserializeObject<Todo>(jsonResponse);

            return todo;
        }

        public async Task<bool> AddTodoAsync(Todo todo)
        {
            var httpClient = new HttpClient();

            var jsonEmployee = JsonConvert.SerializeObject(todo);

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

        public async Task<bool> DeleteTodoAsync(int id)
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

        public async Task EditTodoAsync(Todo todo)
        {
            var httpClient = new HttpClient();

            var jsonEmployee = JsonConvert.SerializeObject(todo);

            var httpContent = new StringContent(jsonEmployee);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PutAsync(BaseUrl + todo.IdTodo, httpContent);
        }
        public async void getAllTodos(Hour hour, double width)
        {
            List<Todo> Listtodos = await GetTodosAsync();
            List<Todo> ListTodos = new List<Todo>();
            foreach(Todo todo in Listtodos)
            {
                if(todo.IdHour == hour.IdHour)
                    ListTodos.Add(todo);
            }

            List<TodoComment> listComments = await commentsData.GetCommentsAsync();
            List<Done> listdones = await doneData.GetDonesAsync();

            List<Todo> lsFinal = AddCredsTodos(ListTodos, listComments, listdones);

            ViewModel.Statique._TodoViewModel.InsertTodos(lsFinal, width);
        }

        private List<Todo> AddCredsTodos(List<Todo> ListTodos, List<TodoComment> listComments, List<Done> listdones)
        {
            foreach (Todo todo in ListTodos)
            {
                foreach (TodoComment comment in listComments)
                {
                    if (todo.IdTodo.Equals(comment.IdTodo))
                    {
                        todo.Comments.Add(comment);
                    }
                }

                foreach (Done done in listdones)
                {
                    if (todo.IdTodo.Equals(done.IdTodo))
                    {
                        todo.Dones.Add(done);
                    }
                }
            }
            return ListTodos;
        }
        public bool iDone(Todo Todo)
        {
            List<Done> dones = Todo.Dones.ToList();
            foreach (Done done in dones)
            {
                if (done.IdUser == Statique._LoggedUser.IdUser)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<Todo> gettodo(Todo todo, double width)
        {
            List<TodoComment> listComments = await commentsData.GetCommentsAsync();
            List<Done> listDones = await doneData.GetDonesAsync();
            return AddCredsToTodo(todo, listComments, listDones, width);

        }
        public Todo AddCredsToTodo(Todo todo, List<TodoComment> listComments, List<Done> listDones, double width)
        {
            todo.Comments.Clear();
            todo.Dones.Clear();
            foreach (TodoComment comment in listComments)
            {
                if (todo.IdTodo.Equals(comment.IdTodo))
                {
                    todo.Comments.Add(comment);
                }
            }
            Statique._TodoCommentViewModel.InsertComments(todo.Comments, width);

            foreach (Done done in listDones)
            {
                if (todo.IdTodo.Equals(done.IdTodo))
                {
                    todo.Dones.Add(done);
                }
            }
            Statique._DoneViewModel.InsertDones(todo.Dones, width);
            return todo;
        }
    }
}
