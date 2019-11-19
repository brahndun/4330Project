using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class WriteDescriptionPage : ContentPage
    {
        public WriteDescriptionPage()
        {
            InitializeComponent();

            if (!String.IsNullOrEmpty(App.UserLoggedIn.Description))
                descriptionEditor.Text = App.UserLoggedIn.Description;
        }

        async void OnNextButtonClicked(object sender, EventArgs e)
        {
            App.UserLoggedIn.Description = descriptionEditor.Text;
            await App.Database.SaveUserAsync(App.UserLoggedIn);
            await Navigation.PushAsync(new UploadProfilePicPage());
        }
    }
}
