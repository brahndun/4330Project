using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class NewPassword : ContentPage
    {
        public NewPassword()
        {
            InitializeComponent();
        }

        public async void ChangePassword(object sender, EventArgs e)
        {
            if (IsValid())
            {
                //Changes the user's password in the database
                User user = RegisteredUsers.registeredUsers.Find(a => a.Email.ToLower() == VerifyCode.sentTo.ToLower());
                if (user != null) {
                    user.Password = passwordEntry.Text;
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                    await Navigation.PopToRootAsync();
                }

                //There should be no reason for the code to enter this else branch.
                //However, it's here just in case.
                else
                {
                    messageLabel.Text = "Unknown error. Contact developers.";
                }

            }
        }

        //This function is used to determine if the user has entered a valid password
        public bool IsValid()
        {
            //This function will only return true if none of the below if statements are true
            bool valid = false;
            if (passwordEntry.Text.Length < 8)
                messageLabel.Text = "Password must be at least 8 characters long";
            else if (passwordEntry.Text != passwordRepeatEntry.Text)
                messageLabel.Text = "Passwords do not match";
            else
                valid = true;
            return valid;
        }
    }
}
