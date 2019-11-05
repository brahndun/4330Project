using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class VerificationCode : ContentPage
    {
        public VerificationCode()
        {
            InitializeComponent();
        }

        public async void ConfirmCode(object sender, EventArgs e)
        {
            if (codeEntry.Text == VerifyCode.code)
            {
                await Navigation.PushAsync(new NewPassword());
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count() - 2]);
            }
            else
            {
                messageLabel.Text = "Code is incorrect";
            }
        }
    }
}
