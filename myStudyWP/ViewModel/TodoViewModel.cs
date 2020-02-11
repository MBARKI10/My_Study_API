using myStudyWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.ViewModel
{
    class TodoViewModel
    {
        public ObservableCollection<Todo> todoCollectionItems { get; set; }

        public TodoViewModel()
        {
            todoCollectionItems = new ObservableCollection<Todo>();
        }

        public void InsertTodos(List<Todo> todos,double width)
        {
            todoCollectionItems.Clear();

            foreach (Todo todo in todos)
            {
                todo.itemWidth = width;
                todoCollectionItems.Add(todo);
            }
        }
        public void InsertTodo(Todo todo)
        {
            todoCollectionItems.Add(todo);
        }
    }
}
