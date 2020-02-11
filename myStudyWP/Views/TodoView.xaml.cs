using myStudyWP.Common;
using myStudyWP.Models;
using myStudyWP.Services;
using myStudyWP.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace myStudyWP.Views
{
   
    public sealed partial class TodoView : Page
    {


        private NavigationHelper navigationhelper;
        private DoneDataService DoneData = new DoneDataService();
        private TodoDataService TodoData = new TodoDataService();

        //private PostComment selecteComment ;
        private TodoCommentDataService CommentData = new TodoCommentDataService();
        private Todo currentTodo = new Todo();
        public TodoView()
        {
            this.InitializeComponent();
            this.navigationhelper = new NavigationHelper(this);


        }
        protected override void OnDoubleTapped(DoubleTappedRoutedEventArgs e)
        {
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
            if(Appbar.Visibility == Visibility.Visible)
                Appbar.Visibility = Visibility.Collapsed;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            currentTodo = e.Parameter as Todo;
            selecteComment = new TodoComment();
            CommentData.getAllComments(currentTodo, Window.Current.Bounds.Width - 50);
            this.DataContext = Statique._TodoCommentViewModel;

            if (TodoData.iDone(currentTodo))
                btdone.Visibility = Visibility.Collapsed;
            stkTodoInfo.DataContext = currentTodo;
        }




        private async void AddComment_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TodoComment comment = new TodoComment();
            comment.IdTodo = currentTodo.IdTodo;
            comment.IdUser = Statique._LoggedUser.IdUser;
            comment.Author = Statique._LoggedUser.Fullname;
            comment.Content = tbComment.Text;
            comment.PublishDate = DateTime.Now;

            var result = await CommentData.AddCommentAsync(comment);
            tbComment.Text = "";
            CommentData.getAllComments(currentTodo, Window.Current.Bounds.Width - 50);
            this.DataContext = Statique._TodoCommentViewModel;


        }

        private async void btdone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Done done = new Done();
            done.IdTodo = currentTodo.IdTodo;
            done.IdUser = Statique._LoggedUser.IdUser;

            Statique._DoneViewModel.InsertDone(done);
            var result = await DoneData.AddDoneAsync(done);
            btdone.Visibility = Visibility.Collapsed;
        }




        private TodoComment selecteComment = new TodoComment();
       


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





        private void commentTodoList_Tapped(object sender, TappedRoutedEventArgs e)
        {

            selecteComment = commentTodoList.SelectedItem as TodoComment;
            if (selecteComment.IdUser == Statique._LoggedUser.IdUser)
            {
                Appbar.Visibility = Visibility.Visible;
                
            }
        }



        private void EditCommen_Click(object sender, RoutedEventArgs e)
        {

            if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
            popupTxt.Text = selecteComment.Content;
        }

       



        private async void btEdite_Click(object sender, RoutedEventArgs e)
        {
            selecteComment.Content = popupTxt.Text;
            await CommentData.EditCommentAsync(selecteComment);
            StandardPopup.IsOpen = false;
            currentTodo = await TodoData.gettodo(currentTodo, Window.Current.Bounds.Width - 40);
            this.DataContext = Statique._TodoCommentViewModel;
            Appbar.Visibility = Visibility.Collapsed;
        }



        private void CancelBtnClick(IUICommand command)
        {
            Appbar.Visibility = Visibility.Collapsed;
        }



        private async void OkBtnClick(IUICommand command)
        {
            var result = await CommentData.DeleteCommentAsync(selecteComment.IdComment);
            currentTodo = await TodoData.gettodo(currentTodo, Window.Current.Bounds.Width - 50);
            Appbar.Visibility = Visibility.Collapsed;

        }

       

        
    }
}
