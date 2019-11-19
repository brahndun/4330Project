using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;

using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class UploadProfilePicPage : ContentPage
    {
        public UploadProfilePicPage()
        {
            InitializeComponent();

            if (App.UserLoggedIn.ProfilePic != null)
            {
                profilePic.Source = ImageSource.FromStream(() => new MemoryStream(App.UserLoggedIn.ProfilePic));
            }

            pickPicture.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight,


                });


                if (file == null)
                    return;
                profilePic.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });

                var memoryStream = new MemoryStream();
                file.GetStream().CopyTo(memoryStream);
                App.UserLoggedIn.ProfilePic = memoryStream.ToArray();
                file.Dispose();
                await App.Database.SaveUserAsync(App.UserLoggedIn);

            };
        }

        public async void OnConfirmButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
            await Navigation.PopToRootAsync();
        }
    }
}
