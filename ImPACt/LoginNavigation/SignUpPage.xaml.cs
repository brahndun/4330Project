using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using LoginNavigation.Models;

namespace LoginNavigation
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            var user = new User();
            user.Email = emailEntry.Text;
            user.Password = passwordEntry.Text;
            /*User user = new User()
            {
                Password = passwordEntry.Text,
                Email = emailEntry.Text
            };*/

            // Sign up logic goes here

            var allUsers = await App.Database.GetUsersAsync();
            if (AreDetailsValid(user, allUsers))
            {
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null)
                {
                    //This should be uploaded to database
                    //RegisteredUsers.registeredUsers.Add(user);
                    await App.Database.SaveUserAsync(user);
                    App.IsUserLoggedIn = true;
                    App.UserLoggedIn = user;
                    Navigation.InsertPageBefore(new MakeProfilePage(), Navigation.NavigationStack.First());
                    await Navigation.PopToRootAsync();
                }
            }
        }

        bool AreDetailsValid(User user, List<User> allUsers)
        {
            bool valid = false;
            //Error when the user didn't enter an email address
            if (user.Email.Length <= 0)
                messageLabel.Text = "Please enter an email address";
            //Error when user's email already exists within the database
            else if (allUsers.Find(x => x.Email.ToLower() == user.Email.ToLower()) != null)
                messageLabel.Text = "Email is already in use";
            //Error when user's email is not a .edu email
            else if (user.Email.Substring(Math.Max(0, user.Email.Length - 4)) != ".edu")
                messageLabel.Text = "Email must be a valid .edu address";
            //Error for when the user's email does not contain a @
            else if (!user.Email.Contains("@"))
                messageLabel.Text = "Email must be valid";
            //Error for when the user's password is too short
            else if (user.Password.Length < 8)
                messageLabel.Text = "Password must have at least 8 characters";
            //Error when the two password entries do not match each other
            else if (user.Password != passwordRepeatEntry.Text)
                messageLabel.Text = "Passwords do not match";
            else
                valid = true;
            return valid;
        }
    }
}
