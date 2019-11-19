using System;
using Xamarin.Forms;
using System.Net.Mail;
using LoginNavigation.Models;

namespace LoginNavigation
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            //THIS IS DEBING CODE, REMOVE LATER
            var us = await App.Database.GetUsersAsync();
            for (int i = 0; i < us.Count; i++)
                us[i].MatchRequestsSent = String.Empty;
            for (int i = 0; i < us.Count; i++)
                await App.Database.SaveUserAsync(us[i]);
            //END OF DEBUGGING

            await Navigation.PushAsync(new SignUpPage());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Email = emailEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                App.UserLoggedIn = await App.Database.GetUserAsync(user.Email, user.Password);
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        async void OnForgotPassword(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPassword());
        }

        //Untested
        bool AreCredentialsCorrect(User user)
        {
            var u = App.Database.GetUserAsync(emailEntry.Text, passwordEntry.Text).Result;
            return u != null;
        }
    }
}
