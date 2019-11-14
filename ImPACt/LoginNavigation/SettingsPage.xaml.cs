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
            await Navigation.PopAsync();
            await Navigation.PushAsync(new LoginPage());
        }
        async void EditProfileClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MakeProfilePage());
        }
    }
}
