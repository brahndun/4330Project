using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class UploadProfilePicPage : ContentPage
    {
        public UploadProfilePicPage()
        {
            InitializeComponent();
            profilePic.Source = ImageSource.FromUri(new Uri("https://images.app.goo.gl/2NiQnSseAaC9Yvwh9"));
        }

        public async void OnConfirmButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
            await Navigation.PopToRootAsync();
        }
    }
}
