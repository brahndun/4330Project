using System;
using System.Collections.Generic;
using LoginNavigation.Models;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using System.ComponentModel;

namespace LoginNavigation
{
    public partial class AssosciatesPage : ContentPage
    {
        public ObservableCollection<User> Associates { get; private set; }

        public AssosciatesPage()
        {
            InitializeComponent();

            //Creates an event that calls OnAssociatesChanged whenever the logged in
            //user's list of associates changes.
            App.UserLoggedIn.PropertyChanged += OnAssociatesChanged;

            //Loads the user's associates onto the page.
            LoadItems();

            //Xamarin requires this to display the data.
            BindingContext = this;

        }

        //Whenever the logged in user's associates list changes, the list on this page changes as well
        public async void OnAssociatesChanged(object sender, PropertyChangedEventArgs e)
        {
            LoadItems();
        }

        //Load the logged in user's associates onto the page.
        public async void LoadItems()
        {
            //If the page's associates list is currently empty, create a new list.
            if (Associates == null)
                Associates = new ObservableCollection<User>();

            //If the user has associates, add them to the page.
            if (!String.IsNullOrEmpty(App.UserLoggedIn.Associates))
            {
                noAssociates.IsVisible = false;

                //Changes the string of IDs stored in the logged in user's MatchRequestsSent property
                //and changes it to a list of IDs
                List<String> associates = new List<String>(App.UserLoggedIn.Associates.Split('^'));

                for (int i = 0; i < associates.Count - 1; i++)
                {
                    int val = Convert.ToInt32(associates[i]);
                    var u = await App.Database.GetUserAsync(val);
                    if (!Associates.Contains(u))
                        Associates.Add(u);
                }
            }
            else
            {
                noAssociates.IsVisible = true;
            }

        }

        async void OnMatchRequestsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActiveMatchesPage());
        }

        async void UserClicked(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new DirectMessaging());
        }
    }
}
