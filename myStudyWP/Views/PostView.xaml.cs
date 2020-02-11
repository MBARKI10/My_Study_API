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

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace myStudyWP.Views
{
    
    public sealed partial class PostView : Page
    {
        private NavigationHelper navigationhelper;
        private LikeDataService LikeData = new LikeDataService();
        private PostDataService PostData = new PostDataService();

        //private PostComment selecteComment ;
        private PostCommentDataService CommentData = new PostCommentDataService();
        private Post currentPost = new Post();
        public PostView()
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
            currentPost = e.Parameter as Post;
            selecteComment = new PostComment();
            CommentData.getAllComments(currentPost, Window.Current.Bounds.Width - 50);
            this.DataContext = Statique._PostCommentViewModel;

            if (PostData.iLike(currentPost))
                btlike.Visibility = Visibility.Collapsed;  
            stkPostInfo.DataContext = currentPost;
        }




        private async void AddComment_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PostComment comment = new PostComment();
            comment.IdPost = currentPost.IdPost;
            comment.IdUser = Statique._LoggedUser.IdUser;
            comment.Author = Statique._LoggedUser.Fullname;
            comment.Content = tbComment.Text;
            comment.PublishDate = DateTime.Now;

            var result = await CommentData.AddCommentAsync(comment);
            tbComment.Text = "";
            CommentData.getAllComments(currentPost, Window.Current.Bounds.Width - 50);
            this.DataContext = Statique._PostCommentViewModel;


        }

        private async void btlike_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Like like = new Like();
            like.IdPost = currentPost.IdPost;
            like.IdUser = Statique._LoggedUser.IdUser;

            Statique._LikeViewModel.InsertLike(like);
            var result = await LikeData.AddLikeAsync(like);
            btlike.Visibility = Visibility.Collapsed;
        }

        

        
        private PostComment selecteComment = new PostComment();
       


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

        

        private void commentPostList_Tapped(object sender, TappedRoutedEventArgs e)
        {

            selecteComment = commentPostList.SelectedItem as PostComment;
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
            currentPost = await PostData.getpost(currentPost, Window.Current.Bounds.Width - 40);
            this.DataContext = Statique._PostCommentViewModel;
            Appbar.Visibility = Visibility.Collapsed;
        }



        private void CancelBtnClick(IUICommand command)
        {
            Appbar.Visibility = Visibility.Collapsed;
        }



        private async void OkBtnClick(IUICommand command)
        {
            var result = await CommentData.DeleteCommentAsync(selecteComment.IdComment);
            currentPost = await PostData.getpost(currentPost, Window.Current.Bounds.Width - 50);
            Appbar.Visibility = Visibility.Collapsed;

        }

    }
}
