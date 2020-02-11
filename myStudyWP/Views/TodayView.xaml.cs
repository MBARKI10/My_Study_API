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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TodayView : Page
    {
        private TodayDataService todayData = new TodayDataService();
        private NavigationHelper navigationhelper; 
        public TodayView()
        {
            this.InitializeComponent();
            this.navigationhelper = new NavigationHelper(this);

        }

        

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
           await todayData.update(Window.Current.Bounds.Width - 50);
           this.DataContext = Statique._TodayViewModel;
        }

      

        private void ClassesListView_ItemClick(object sender, ItemClickEventArgs e)
        { var selected = e.ClickedItem as Hour;
            this.Frame.Navigate(typeof(Views.SessionView),selected);
        }

        private void EventsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selected = e.ClickedItem as Event;
            this.Frame.Navigate(typeof(Views.EventView), selected);
        }

        private void TodosListViews_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selected = e.ClickedItem as Todo;
            this.Frame.Navigate(typeof(Views.TodoView), selected);
        }
    }
}
