using System;

using Xamarin.Forms;

namespace LoginNavigation.Droid
{
    public class ForgotPassword : ContentPage
    {
        public ForgotPassword()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

