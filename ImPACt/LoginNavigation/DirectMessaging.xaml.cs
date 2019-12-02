using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class DirectMessaging : ContentPage
    {
        public DirectMessaging()
        {
            InitializeComponent();
        }

        public void SendMessage(object sender, EventArgs e)
        {
            /*
             * <Frame BackgroundColor="#4fa8e8"
                   Grid.Row="1"
                   Margin="0,0,0,15"
                   WidthRequest="180"
                   CornerRadius="10"
                   HorizontalOptions="Start"
                   HasShadow="True">
                <Label Text="You're welcome. I'm looking forward to working together." />
            </Frame> */

            Frame frame = new Frame()
            {
                Margin = new Thickness(0, 0, 0, 15),
                WidthRequest = 180,
                CornerRadius = 10,
                HorizontalOptions = LayoutOptions.Start,
                HasShadow = true,
                BackgroundColor = Color.FromHex("#4fa8e8"),
                Content = new Label() { Text = newMessageEditor.Text}
            };

            messageStackLayout.Children.Add(frame);

            newMessageEditor.Text = String.Empty;
        }
    }
}
