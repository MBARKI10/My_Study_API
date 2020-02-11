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

    public sealed partial class EventView : Page
    {
        private NavigationHelper navigationhelper;
        private ParticipateDataService ParticipateData = new ParticipateDataService();
        private EventDataService EventData = new EventDataService();

        //private PostComment selecteComment ;
        private EventCommentDataService CommentData = new EventCommentDataService();
        private Event currentEvent = new Event();
        public EventView()
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
            currentEvent = e.Parameter as Event;
            selecteComment = new EventComment();
            CommentData.getAllComments(currentEvent, Window.Current.Bounds.Width - 50);
            this.DataContext = Statique._EventCommentViewModel;

            if (EventData.iParticipate(currentEvent))
                btParticipate.Visibility = Visibility.Collapsed;
            stkEventInfo.DataContext = currentEvent;
        }




        private async void AddComment_Tapped(object sender, TappedRoutedEventArgs e)
        {
            EventComment comment = new EventComment();
            comment.IdEvent = currentEvent.IdEvent;
            comment.IdUser = Statique._LoggedUser.IdUser;
            comment.Author = Statique._LoggedUser.Fullname;
            comment.Content = tbComment.Text;
            comment.PublishDate = DateTime.Now;

            var result = await CommentData.AddCommentAsync(comment);
            tbComment.Text = "";
            CommentData.getAllComments(currentEvent, Window.Current.Bounds.Width - 50);
            this.DataContext = Statique._EventCommentViewModel;


        }

        private async void Participate_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Participate participate = new Participate();
            participate.IdEvent = currentEvent.IdEvent;
            participate.IdUser = Statique._LoggedUser.IdUser;

            Statique._ParticipateViewModel.InsertParticipate(participate);
            var result = await ParticipateData.AddParticipateAsync(participate);
            btParticipate.Visibility = Visibility.Collapsed;
        }

        

        
        private EventComment selecteComment = new EventComment();
       


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

        



        private void commentEventList_Tapped(object sender, TappedRoutedEventArgs e)
        {

            selecteComment = commentEventList.SelectedItem as EventComment;
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
            currentEvent = await EventData.getevent(currentEvent, Window.Current.Bounds.Width - 40);
            this.DataContext = Statique._EventCommentViewModel;
            Appbar.Visibility = Visibility.Collapsed;
        }



        private void CancelBtnClick(IUICommand command)
        {
            Appbar.Visibility = Visibility.Collapsed;
        }



        private async void OkBtnClick(IUICommand command)
        {
            var result = await CommentData.DeleteCommentAsync(selecteComment.IdComment);
            currentEvent = await EventData.getevent(currentEvent, Window.Current.Bounds.Width - 50);
            Appbar.Visibility = Visibility.Collapsed;

        }

      
    }
}
