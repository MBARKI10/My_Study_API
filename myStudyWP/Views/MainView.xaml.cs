using myStudyWP.Models;
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


namespace myStudyWP.Views
{

    public sealed partial class MainView : Page
    {
        public MainView()
        {
            this.InitializeComponent();
        }
        private User loggedUser = Statique._LoggedUser;
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
          
        }

       
            
           
        
       

        

          
        

        private void Classes_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.ClasseView));
        }

        private void Today_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.TodayView));
        }

        private void Events_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.EventsView));
        }

        private void Posts_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.PostsView));
        }
    }
}
