using System;
using System.Collections.Generic;
using LoginNavigation.Models;

using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class AssosciatesPage : ContentPage
    {
        public IList<User> Associates { get; private set; }

        public AssosciatesPage()
        {
            InitializeComponent();

            Associates = new List<User>();
            Associates.Add(new User() { FirstName = "Emily", LastName = "Johnson" });
            Associates.Add(new User() { FirstName = "William", LastName = "Taft" });
            Associates.Add(new User() { FirstName = "Bobby", LastName = "Brown" });

            BindingContext = this;




        }

        async void OnMatchRequestsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActiveMatchesPage());
        }
    }
}
