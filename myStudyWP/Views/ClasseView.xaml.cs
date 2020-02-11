using myStudyWP.Common;
using myStudyWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    
    public sealed partial class ClasseView : Page
    {
        private NavigationHelper navigationhelper; 
        private Hour selectedHour = new Hour();

        public ClasseView()
        {
            this.InitializeComponent();
            this.navigationhelper = new NavigationHelper(this);
            this.DataContext = ViewModel.Statique._ClasseViewModel;

            if(DateTime.Today.DayOfWeek==DayOfWeek.Monday){

                pivot.SelectedIndex=0;
            }
            if (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
            {

                pivot.SelectedIndex = 1;
            }
            if (DateTime.Today.DayOfWeek == DayOfWeek.Wednesday)
            {

                pivot.SelectedIndex = 2;
            }
            if (DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
            {

                pivot.SelectedIndex = 3;
            }
            if (DateTime.Today.DayOfWeek == DayOfWeek.Friday)
            {

                pivot.SelectedIndex = 4;
            }
            if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
            {

                pivot.SelectedIndex = 5;
            }
        }

        
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void MondayListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            selectedHour = e.ClickedItem as Hour;

            this.Frame.Navigate(typeof(Views.SessionView), selectedHour);
        }

        private void TuesdayListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            selectedHour = e.ClickedItem as Hour;

            this.Frame.Navigate(typeof(Views.SessionView), selectedHour);
        }

        private void WednesdayListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            selectedHour = e.ClickedItem as Hour;

            this.Frame.Navigate(typeof(Views.SessionView), selectedHour);
        }

        private void ThursdayListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            selectedHour = e.ClickedItem as Hour;

            this.Frame.Navigate(typeof(Views.SessionView), selectedHour);
        }

        private void FridayListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            selectedHour = e.ClickedItem as Hour;

            this.Frame.Navigate(typeof(Views.SessionView), selectedHour);
        }

        private void SaturdayListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            selectedHour = e.ClickedItem as Hour;

            this.Frame.Navigate(typeof(Views.SessionView), selectedHour);
        }

       
    }
}
