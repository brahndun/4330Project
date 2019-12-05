using System;
using Xamarin.Forms;
using System.Net.Mail;
using LoginNavigation.Models;

namespace LoginNavigation
{
    public partial class LoginPage : ContentPage
    {
        //Constructor for the LoginPage
        public LoginPage()
        {
            InitializeComponent();
        }

        //Moves to the sign up bage if the sign up button is clicked, mapped to the SignUp button on the .xaml page.
        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        //Tries logging in if the login button is clicked, mapped to the Login button on the .xaml page.
        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            //create a temporary local user to store the given information from the form.
            var user = new User
            {
                Email = emailEntry.Text,
                Password = passwordEntry.Text
            };
            //Checks to see if the login information is valid.  
            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                //If the credentials provided are valid, the user is logged in.
                App.IsUserLoggedIn = true;
                App.UserLoggedIn = await App.Database.GetUserAsync(user.Email, user.Password);
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                //If the credentials provided are invalid, the user is told the Login failed and the password entry box is cleared.
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        //The function mapped to Forgot Password button in the .xaml page.  This takes the user to the Forgot Password page of the app.
        async void OnForgotPassword(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPassword());
        }

        //Untested, should check to see if the typed credentials provided match up in the database.
        bool AreCredentialsCorrect(User user)
        {
            var u = App.Database.GetUserAsync(emailEntry.Text, passwordEntry.Text).Result;
            return u != null;
        }
    }
}
