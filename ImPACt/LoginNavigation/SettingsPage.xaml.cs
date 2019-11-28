using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            List<String> interests = new List<String>(App.UserLoggedIn.Interests.Split('^'));
            for (int i = 0; i < interests.Count; i++)
                interestsLabel.Text += interests[i] + ", ";
            if (!String.IsNullOrEmpty(interestsLabel.Text))
                interestsLabel.Text = interestsLabel.Text.Remove(interestsLabel.Text.Length - 2);

            nameLabel.Text = App.UserLoggedIn.FullName;
        }
        async void LogOut(object sender, EventArgs e)
        {
            App.tabbedPage.currentMatchesPage.Reset();
            App.IsUserLoggedIn = false;
            App.UserLoggedIn = null;
            var navPage = new NavigationPage(new LoginPage());
            navPage.BarBackgroundColor = Color.FromRgb(79, 168, 232);
            navPage.BarTextColor = Color.White;
            App.Current.MainPage = navPage;
        }
        async void SwitchToJacksonLambert(object sender, EventArgs e)
        {
            App.UserLoggedIn = await App.Database.GetUserAsync(2);
            await Navigation.PopAsync();
            await Navigation.PushAsync(new MainPage());
        }

        async void EditProfileClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MakeProfilePage());
        }

        async void EraseMatchRequestsTapped(object sender, EventArgs e)
        {
            var users = await App.Database.GetUsersAsync();
            for (int i = 0; i < users.Count; i++)
            {
                users[i].MatchRequestsReceived = String.Empty;
                users[i].MatchRequestsSent = String.Empty;
                await App.Database.SaveUserAsync(users[i]);
            }
        }
        async void EraseInterestsTapped(object sender, EventArgs e)
        {
            var users = await App.Database.GetUsersAsync();
            for (int i = 0; i < users.Count; i++)
            {
                users[i].Interests = String.Empty;
                await App.Database.SaveUserAsync(users[i]);
            }
        }
        async void EraseAssociatesTapped(object sender, EventArgs e)
        {
            var users = await App.Database.GetUsersAsync();
            for (int i = 0; i < users.Count; i++)
            {
                users[i].Associates = String.Empty;
                await App.Database.SaveUserAsync(users[i]);
            }

        }

        async void TenUsersTapped(object sender, EventArgs e)
        {
            var users = await App.Database.GetUsersAsync();
            for (int i = 9; i < users.Count; i++)
            {
                await App.Database.DeleteUserAsync(users[i]);
            }
        }

    }
}
