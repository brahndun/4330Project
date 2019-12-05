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

        //When the send button is pressed, send the message to the other user.
        public void SendMessage(object sender, EventArgs e)
        {

            //Creates a new text message with the content from the message editor
            Frame frame = new Frame()
            {
                Margin = new Thickness(0, 0, 0, 15),
                WidthRequest = 180,
                CornerRadius = 10,
                HorizontalOptions = LayoutOptions.End,
                HasShadow = true,
                BackgroundColor = Color.FromHex("#4fa8e8"),
                Content = new Label() { Text = newMessageEditor.Text}
            };

            messageStackLayout.Children.Add(frame);

            //Empty the editor
            newMessageEditor.Text = String.Empty;
        }
    }
}
