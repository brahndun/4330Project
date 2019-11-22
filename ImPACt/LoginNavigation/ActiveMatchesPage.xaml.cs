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

            App.UserLoggedIn.PropertyChanged += OnRequestsChanged;

            LoadItems();

            BindingContext = this;
        }

        public async void OnRequestsChanged(object sender, PropertyChangedEventArgs e)
        {
            LoadItems();
        }

        async void LoadItems()
        {

            if (MatchRequests == null)
                MatchRequests = new ObservableCollection<User>();
            else
                MatchRequests.Clear();

            if (!String.IsNullOrEmpty(App.UserLoggedIn.MatchRequestsSent))
            {

                noMatches.IsVisible = false;
                //Changes the string of IDs stored in the logged in user's MatchRequestsSent property
                //and changes it to a list of IDs
                List<String> matchRequestsSent = new List<String>(App.UserLoggedIn.MatchRequestsSent.Split('^'));

                for (int i = 0; i < matchRequestsSent.Count - 1; i++)
                {
                    Console.WriteLine("val: " + matchRequestsSent[i]);
                    int val = Convert.ToInt32(matchRequestsSent[i]);
                    var u = await App.Database.GetUserAsync(val);
                    if (!MatchRequests.Contains(u)) 
                        MatchRequests.Add(u);
                }
            }

            else if (!String.IsNullOrEmpty(App.UserLoggedIn.MatchRequestsReceived))
            {
                noMatches.IsVisible = false;
                //Changes the string of IDs stored in the logged in user's MatchRequestsSent property
                //and changes it to a list of IDs
                List<String> matchRequestsReceived = new List<String>(App.UserLoggedIn.MatchRequestsReceived.Split('^'));

                for (int i = 0; i < matchRequestsReceived.Count - 1; i++)
                {
                    Console.WriteLine("val: " + matchRequestsReceived[i]);
                    int val = Convert.ToInt32(matchRequestsReceived[i]);
                    var u = await App.Database.GetUserAsync(val);
                    if (!MatchRequests.Contains(u))
                        MatchRequests.Add(u);
                }
            }
            else
            {
                noMatches.IsVisible = true;
            }
        }

        public void UserClicked(object sender, ItemTappedEventArgs e)
        {
            User u = (User)e.Item;
            App.tabbedPage.CurrentPage = App.tabbedPage.Children[0];
            App.tabbedPage.currentMatchesPage.GoToUser(u);
        }
    }
}
