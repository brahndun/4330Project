using System;
using System.Collections.Generic;
using LoginNavigation.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

using Xamarin.Forms;


namespace LoginNavigation
{
    public partial class ActiveMatchesPage : ContentPage
    {
        public ObservableCollection<User> MatchRequests { get; private set; }

        public ActiveMatchesPage()
        {
            InitializeComponent();

            //Adds an event to the logged in user. Whenever their match requests change,
            //the list on this page containing the user's match requests will update
            App.UserLoggedIn.PropertyChanged += OnRequestsChanged;

            //Loads the user's match requests onto the page.
            LoadItems();

            //Xamarin requires this to be able to display the match requests
            BindingContext = this;
        }

        //This function is called whenever the user's requests change. It reloads the
        //user's interests onto the page
        public async void OnRequestsChanged(object sender, PropertyChangedEventArgs e)
        {
            LoadItems();
        }

        //Loads the user's interests onto the page
        async void LoadItems()
        {
            //If the current MatchRequests list on this page is null, create a list.
            //Otherwise, clear it and readd the elements.
            if (MatchRequests == null)
                MatchRequests = new ObservableCollection<User>();
            else
                MatchRequests.Clear();

            //If the user has sent match requests to other users, load them o
            if (!String.IsNullOrEmpty(App.UserLoggedIn.MatchRequestsSent))
            {

                noMatches.IsVisible = false;
                //Changes the string of IDs stored in the logged in user's MatchRequestsSent property
                //and changes it to a list of IDs
                List<String> matchRequestsSent = new List<String>(App.UserLoggedIn.MatchRequestsSent.Split('^'));

                for (int i = 0; i < matchRequestsSent.Count - 1; i++)
                {
                    int val = Convert.ToInt32(matchRequestsSent[i]);
                    var u = await App.Database.GetUserAsync(val);
                    if (!MatchRequests.Contains(u)) 
                        MatchRequests.Add(u);
                }
            }

            //If the user has received match requests from other users, load them onto the page
            else if (!String.IsNullOrEmpty(App.UserLoggedIn.MatchRequestsReceived))
            {
                noMatches.IsVisible = false;
                //Changes the string of IDs stored in the logged in user's MatchRequestsSent property
                //and changes it to a list of IDs
                List<String> matchRequestsReceived = new List<String>(App.UserLoggedIn.MatchRequestsReceived.Split('^'));

                for (int i = 0; i < matchRequestsReceived.Count - 1; i++)
                {
                    int val = Convert.ToInt32(matchRequestsReceived[i]);
                    var u = await App.Database.GetUserAsync(val);
                    if (!MatchRequests.Contains(u))
                        MatchRequests.Add(u);
                }
            }
            //If the user has no match requests at all, show a notification on the page stating so.
            else
            {
                noMatches.IsVisible = true;
            }
        }

        //If the user clicks one of the match requests loaded on the page, the app will
        //redirect them to that user's page.
        public void UserClicked(object sender, ItemTappedEventArgs e)
        {
            User u = (User)e.Item;
            App.tabbedPage.CurrentPage = App.tabbedPage.Children[0];
            App.tabbedPage.currentMatchesPage.GoToUser(u);
        }
    }
}
