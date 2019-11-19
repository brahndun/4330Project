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
        }
        async void LogOut(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            App.UserLoggedIn = null;
            await Navigation.PopAsync();
            await Navigation.PushAsync(new LoginPage());
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
            App.UserLoggedIn.MatchRequestsSent = String.Empty;
            await App.Database.SaveUserAsync(App.UserLoggedIn);
        }

    }
}
