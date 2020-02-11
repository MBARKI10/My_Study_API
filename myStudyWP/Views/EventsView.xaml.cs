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
using Windows.Graphics.Display;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace myStudyWP.Views
{

    public sealed partial class EventsView : Page
    {
        private NavigationHelper navigationHelper;
        private Event selectedEvent = new Event();
        EventDataService eventData = new EventDataService();
       

        public EventsView()
        {
            this.InitializeComponent();
            eventData.getAllEvents(Window.Current.Bounds.Width - 50);
            this.DataContext = ViewModel.Statique._EventViewModel;
            this.navigationHelper = new NavigationHelper(this);

            dpEvent.MinYear = DateTimeOffset.Now;
            dpEvent.MaxYear = DateTimeOffset.Now;

        }
     

        private void AllEvents_ItemClick(object sender, ItemClickEventArgs e)
        {
            selectedEvent = e.ClickedItem as Event;

            this.Frame.Navigate(typeof(Views.EventView), selectedEvent);
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

        private async void btnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            Event myEvent = new Event();
            myEvent.Author = Statique._LoggedUser.Fullname;
            myEvent.IdUser = Statique._LoggedUser.IdUser;
            myEvent.Club = tbclub.Text;
            myEvent.DeadlineDate = dpEvent.Date.Date;
            myEvent.PublishDate = DateTime.Now;
            myEvent.Title = "hello";
            myEvent.Description = txtEventContent.Text;

            var result = await eventData.AddEventAsync(myEvent);
            eventData.getAllEvents(Window.Current.Bounds.Width - 50);
            this.DataContext = ViewModel.Statique._EventViewModel;

        }

        private void EditCommen_Click(object sender, RoutedEventArgs e)
        {

            if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
            popupTxt.Text = selectedEvent.Description;
            popupDate.Date = selectedEvent.DeadlineDate;
            popupTxtClub.Text = selectedEvent.Club;
        }





        private async void btEdite_Click(object sender, RoutedEventArgs e)
        {
            selectedEvent.Description = popupTxt.Text;
            selectedEvent.Club = popupTxtClub.Text;
            selectedEvent.DeadlineDate = popupDate.Date.Date;
            await eventData.EditEventAsync(selectedEvent);
            StandardPopup.IsOpen = false;
            eventData.getAllEvents(Window.Current.Bounds.Width - 50);
            this.DataContext = Statique._EventViewModel;
            Appbar.Visibility = Visibility.Collapsed;
        }



        private void CancelBtnClick(IUICommand command)
        {
            Appbar.Visibility = Visibility.Collapsed;
        }



        private async void OkBtnClick(IUICommand command)
        {
            var result = await eventData.DeleteEventAsync(selectedEvent.IdEvent);
            eventData.getAllEvents(Window.Current.Bounds.Width - 50);
            Appbar.Visibility = Visibility.Collapsed;

        }


        private void Grid_Holding(object sender, HoldingRoutedEventArgs e)
        {

            FrameworkElement senderElement = sender as FrameworkElement;

            selectedEvent = senderElement.DataContext as Event;
            if (selectedEvent.IdUser == Statique._LoggedUser.IdUser)
            {
                Appbar.Visibility = Visibility.Visible;

            }
        }
    }
}
