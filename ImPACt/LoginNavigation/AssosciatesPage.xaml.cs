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

            App.UserLoggedIn.PropertyChanged += OnAssociatesChanged;

            LoadItems();

            BindingContext = this;

        }

        public async void OnAssociatesChanged(object sender, PropertyChangedEventArgs e)
        {
            LoadItems();
        }
        
        public async void LoadItems()
        {
            if (Associates == null)
                Associates = new ObservableCollection<User>();

            if (!String.IsNullOrEmpty(App.UserLoggedIn.Associates))
            {
                noAssociates.IsVisible = false;

                //Changes the string of IDs stored in the logged in user's MatchRequestsSent property
                //and changes it to a list of IDs
                List<String> associates = new List<String>(App.UserLoggedIn.Associates.Split('^'));

                for (int i = 0; i < associates.Count - 1; i++)
                {
                    Console.WriteLine("val: " + associates[i]);
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
