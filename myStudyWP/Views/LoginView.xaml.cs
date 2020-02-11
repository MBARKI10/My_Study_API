using myStudyWP.Models;
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


namespace myStudyWP.Views
{

    public sealed partial class LoginView : Page
    {
        Services.UserDataService userData = new Services.UserDataService();
        Services.GroupDataService groupData = new Services.GroupDataService();

        public LoginView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
        }

        private void btnReister_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.RegisterView));
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //verfifier les champs
            tbUserName.Text = "frere";
            tbPassword.Password = "frere";

            User loggedUser = await userData.UserLogin(tbUserName.Text, tbPassword.Password.ToString());
            Statique._LoggedUser = loggedUser;
            if (loggedUser != null)
            {
                groupData.getMyClasse(loggedUser.Classe, Window.Current.Bounds.Width - 50);
                this.Frame.Navigate(typeof(Views.MainView), loggedUser);
            }
            else
            {
                MessageDialog msg = new MessageDialog("User not exist.", "Error!");
                await msg.ShowAsync();
            }
               
        }
    }
}
