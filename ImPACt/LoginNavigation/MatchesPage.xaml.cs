using System;
using System.Collections.Generic;
using LoginNavigation.Models;

using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class MatchesPage : ContentPage
    {
        public MatchesPage()
        {
            InitializeComponent();

            TestDatabase();
        }
        public async void TestDatabase()
        {
            
            messageBox.Text = "";
            List<User> allUsers = await App.Database.GetNotesAsync();
            for (int i = 0; i < allUsers.Count; i++)
            {
                messageBox.Text += "ID: " + allUsers[i].ID + ", ";
                messageBox.Text += "Email: " + allUsers[i].Email + ", ";
                messageBox.Text += "Password: " + allUsers[i].Password + ", ";
                messageBox.Text += "\n";
            }
            
        }
    }
}
