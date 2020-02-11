using myStudyWP.Common;
using myStudyWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using myStudyWP.ViewModel;
using myStudyWP.Services;
using Windows.UI.Popups;


namespace myStudyWP.Views
{

    public sealed partial class SessionView : Page
    {
        private NavigationHelper navigationhelper;
        private Todo selectedTodo = new Todo(); 
        private Hour selectedhour = new Hour();
        private TodoDataService TodoData = new TodoDataService();
        



        public SessionView()
        {
            this.InitializeComponent();
            this.navigationhelper = new NavigationHelper(this);
            this.DataContext = ViewModel.Statique._TodoViewModel;
           
        }

    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            selectedhour = e.Parameter as Hour;

            TodoData.getAllTodos(selectedhour, Window.Current.Bounds.Width - 50);
            stkSessionInfo.DataContext = selectedhour;
        }
        protected override void OnDoubleTapped(DoubleTappedRoutedEventArgs e)
        {
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
            if (Appbar.Visibility == Visibility.Visible)
                Appbar.Visibility = Visibility.Collapsed;
        }

        private async void DeleteComment_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msgDialog = new MessageDialog("Your message", "Your title");

            //OK Button
            UICommand okBtn = new UICommand("OK");
            okBtn.Invoked = OkBtnClick;
            msgDialog.Commands.Add(okBtn);

            //Cancel Button
            UICommand cancelBtn = new UICommand("Cancel");
            cancelBtn.Invoked = CancelBtnClick;
            msgDialog.Commands.Add(cancelBtn);

            //Show message
            await msgDialog.ShowAsync();


        }
       

        private async void AddTodo_evnt(object sender, TappedRoutedEventArgs e)
        {
            Todo todo = new Todo();

            todo.Author = Statique._LoggedUser.Fullname;
            todo.Content = tbTodo.Text;
            todo.DeadlineDate = dpTodo.Date.Date;
            todo.IdHour = selectedhour.IdHour;
            todo.IdUser = Statique._LoggedUser.IdUser;
            todo.PublishDate = DateTime.Now;
            Statique._TodoViewModel.InsertTodo(todo);

            var result = await TodoData.AddTodoAsync(todo);
            if (result)
            {
                MessageDialog msg = new MessageDialog("added");
                await msg.ShowAsync();
                tbTodo.Text = "";
                TodoData.getAllTodos(selectedhour, Window.Current.Bounds.Width - 50);
                this.DataContext = ViewModel.Statique._TodoViewModel;
            }
            else
            {
                MessageDialog msg = new MessageDialog("erreure");
                await msg.ShowAsync();
            }
        }

        private void AllTodos_ItemClick_1(object sender, ItemClickEventArgs e)
        {
              selectedTodo = e.ClickedItem as Todo;

            this.Frame.Navigate(typeof(Views.TodoView), selectedTodo);
        }

        private void EditCommen_Click(object sender, RoutedEventArgs e)
        {

            if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
            popupTxt.Text = selectedTodo.Content;
            popupDate.Date = selectedTodo.DeadlineDate;
            
        }





        private async void btEdite_Click(object sender, RoutedEventArgs e)
        {
            selectedTodo.Content = popupTxt.Text;
            selectedTodo.DeadlineDate = popupDate.Date.Date;
            await TodoData.EditTodoAsync(selectedTodo);
            StandardPopup.IsOpen = false;
            TodoData.getAllTodos(selectedhour,Window.Current.Bounds.Width - 50);
            this.DataContext = Statique._TodoViewModel;
            Appbar.Visibility = Visibility.Collapsed;
        }



        private void CancelBtnClick(IUICommand command)
        {
            Appbar.Visibility = Visibility.Collapsed;
        }



        private async void OkBtnClick(IUICommand command)
        {
            var result = await TodoData.DeleteTodoAsync(selectedTodo.IdTodo);
            TodoData.getAllTodos(selectedhour,Window.Current.Bounds.Width - 50);
            Appbar.Visibility = Visibility.Collapsed;

        }


        private void Grid_Holding(object sender, HoldingRoutedEventArgs e)
        {

            FrameworkElement senderElement = sender as FrameworkElement;

            selectedTodo = senderElement.DataContext as Todo;
            if (selectedTodo.IdUser == Statique._LoggedUser.IdUser)
            {
                Appbar.Visibility = Visibility.Visible;

            }
        }

       
    }
}
