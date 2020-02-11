using myStudyWP.Models;
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
using myStudyWP.Common;
using myStudyWP.ViewModel;
using System.Collections.ObjectModel;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace myStudyWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PostsView : Page
    {
        private NavigationHelper navigationhelper;
        private Post selectedPost = new Post();
        Services.PostDataService postData = new Services.PostDataService();
       
        private Post selectePost = new Post();
        public PostsView()
        {
            this.InitializeComponent();
            postData.getAllPosts(Window.Current.Bounds.Width - 50);
            this.DataContext = ViewModel.Statique._PostViewModel;
            this.navigationhelper = new NavigationHelper(this);

        }


        protected override void OnDoubleTapped(DoubleTappedRoutedEventArgs e)
        {
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
            if (Appbar.Visibility == Visibility.Visible)
                Appbar.Visibility = Visibility.Collapsed;
        }

        private  void ShowPost_ItemClick(object sender, ItemClickEventArgs e)
        {
            selectedPost = e.ClickedItem as Post;
            this.Frame.Navigate(typeof(Views.PostView), selectedPost);
        }


       private async void btnAddPost_Click(object sender, RoutedEventArgs e)
        {
            Post myPost = new Post();
            myPost.Author = Statique._LoggedUser.Fullname;
            myPost.IdUser = Statique._LoggedUser.IdUser;
            myPost.Title = " " ;
            myPost.Description = txtPostContent.Text;
            myPost.PublishDate = DateTime.Now;
            myPost.IdSubgroup = Statique._LoggedUser.IdSubgroup;

            var result = await postData.AddPostAsync(myPost);
                
                pivot.SelectedItem = allPosts;
                postData.getAllPosts(Window.Current.Bounds.Width - 50);
                this.DataContext = ViewModel.Statique._PostViewModel;
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

      

       private void EditCommen_Click(object sender, RoutedEventArgs e)
       {

           if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
           popupTxt.Text = selectePost.Description;
       }





       private async void btEdite_Click(object sender, RoutedEventArgs e)
       {
           selectePost.Description = popupTxt.Text;
           await postData.EditPostAsync(selectePost);
           StandardPopup.IsOpen = false;
           postData.getAllPosts(Window.Current.Bounds.Width - 50);
           this.DataContext = Statique._PostViewModel;
           Appbar.Visibility = Visibility.Collapsed;
       }



       private void CancelBtnClick(IUICommand command)
       {
           Appbar.Visibility = Visibility.Collapsed;
       }



       private async void OkBtnClick(IUICommand command)
       {
           var result = await postData.DeletePostAsync(selectePost.IdPost);
           postData.getAllPosts(Window.Current.Bounds.Width - 50);
           Appbar.Visibility = Visibility.Collapsed;

       }

       private void AllPosts_Holding_1(object sender, HoldingRoutedEventArgs e)
       {
           FrameworkElement senderElement = sender as FrameworkElement;

           selectePost = senderElement.DataContext as Post;
           if (selectePost.IdUser == Statique._LoggedUser.IdUser)
           {
               Appbar.Visibility = Visibility.Visible;

           }
       }

     


       
    }
}
