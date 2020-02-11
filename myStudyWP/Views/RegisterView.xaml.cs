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

    public sealed partial class RegisterView : Page
    {
        Services.UserDataService userData = new Services.UserDataService();
        Services.GroupDataService groupData = new Services.GroupDataService();

        public RegisterView()
        {
            this.InitializeComponent();
        }


        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var lsLabelGroups = await groupData.GetGroupsLabel();
            cbClasse.ItemsSource = lsLabelGroups;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //vérifier les champ
            //verifier password & confirm password
            if (tbUserName.Text.Length < 4)
            {
                MessageDialog msg = new MessageDialog(userData.ErrorMessage, "Error! UserName must be at least 5 character");
                await msg.ShowAsync();
            }
            else if (tbPassword.Password.Length < 4)
            {
                MessageDialog msg = new MessageDialog(userData.ErrorMessage, "Error! Password must be at least 5 character");
                await msg.ShowAsync();
            }
            else if (tbPasswordConfirm.Password != tbPassword.Password)
            {
                MessageDialog msg = new MessageDialog(userData.ErrorMessage, "Error! Confirm your password");
                await msg.ShowAsync();
            }
            else if (tbNomPreNom.Text.Length < 4)
            {
                MessageDialog msg = new MessageDialog(userData.ErrorMessage, "Error! NomPrenom must be at least 5 character");
                await msg.ShowAsync();
            }
            else
            {
                User userToAdd = new User();

                userToAdd.Username = tbUserName.Text;
                userToAdd.Password = tbPassword.Password.ToString();
                userToAdd.Fullname = tbNomPreNom.Text;
                userToAdd.Classe = cbClasse.SelectedItem.ToString();

                var result = await userData.AddUserAsync(userToAdd);
                
                if (result)
                {
                    
                    groupData.getMyClasse(userToAdd.Classe, Window.Current.Bounds.Width - 50);
                    Statique._LoggedUser = userToAdd;
                    this.Frame.Navigate(typeof(Views.MainView), userToAdd);
                    
                }
                else
                {
                    MessageDialog msg = new MessageDialog(userData.ErrorMessage, "Error!");
                    await msg.ShowAsync();
                }
            }
        }



       
    }
}
