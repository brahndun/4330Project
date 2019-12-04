using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class EnterInterestsPage : ContentPage
    {
        List<String> interests = new List<String>();
        public EnterInterestsPage()
        {
            InitializeComponent();
        }

        //When the enter key is pressed after typing in an interest, this function adds the typed interest to the user's list of interests
        //Then uploads it to the displayed list of interests.
        public void EnterPressed(object sender, EventArgs e)
        {
            //Users can only have 10 interests at maximum.
            if (allInterests.Children.Count < 10)
            {
                //Takes the input from the inputEntry entry box and adds it
                //to the list of all the user's interests
                Label label = new Label();
                label.Text = interestEntry.Text;
                interestEntry.Text = "";
                label.LineHeight = 1.5;
                allInterests.Children.Add(label);
                interests.Add(label.Text);
                //Refocuses on the entry box after pressing enter, to make
                //it for the easier to quickly input more interests.
                interestEntry.Focus();
            }
        }

        //When next is cliked, the added interests is added to the current user's list of interests on the database and the app proceeds
        //to the next screen.
        public async void OnNextButtonClicked(object sender, EventArgs e)
        {
            App.UserLoggedIn.Interests = String.Join("^", interests.ToArray());
            await App.Database.SaveUserAsync(App.UserLoggedIn);
            await Navigation.PushAsync(new WriteDescriptionPage());
        }
    }
}
