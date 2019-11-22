﻿using System;
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
            App.UserLoggedIn.MatchRequestsSent = String.Empty;
            await App.Database.SaveUserAsync(App.UserLoggedIn);
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

    }
}
