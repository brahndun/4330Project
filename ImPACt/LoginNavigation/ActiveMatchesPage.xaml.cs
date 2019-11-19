using System;
using System.Collections.Generic;
using LoginNavigation.Models;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class ActiveMatchesPage : ContentPage
    {
        public ObservableCollection<User> MatchRequests { get; private set; }

        public ActiveMatchesPage()
        {
            InitializeComponent();

            LoadItems();

            BindingContext = this;
        }

        async void LoadItems()
        {
            MatchRequests = new ObservableCollection<User>();

            if (!String.IsNullOrEmpty(App.UserLoggedIn.MatchRequestsSent))
            {
                //Changes the string of IDs stored in the logged in user's MatchRequestsSent property
                //and changes it to a list of IDs
                List<String> matchRequestsSent = new List<String>(App.UserLoggedIn.MatchRequestsSent.Split('^'));

                for (int i = 0; i < matchRequestsSent.Count - 1; i++)
                {
                    Console.WriteLine("val: " + matchRequestsSent[i]);
                    int val = Convert.ToInt32(matchRequestsSent[i]);
                    var u = await App.Database.GetUserAsync(val);
                    MatchRequests.Add(u);
                }
            }
            else
            {
                noMatches.IsVisible = true;
            }
        }
    }
}
