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

            //Loads the user's description if they already have one saved to their profile
            if (!String.IsNullOrEmpty(App.UserLoggedIn.Description))
                descriptionEditor.Text = App.UserLoggedIn.Description;
        }

        //Saves the user's information they have inputted
        async void OnNextButtonClicked(object sender, EventArgs e)
        {
            App.UserLoggedIn.Description = descriptionEditor.Text;
            await App.Database.SaveUserAsync(App.UserLoggedIn);
            await Navigation.PushAsync(new UploadProfilePicPage());
        }
    }
}
