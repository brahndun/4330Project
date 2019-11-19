using System;
using System.Collections.Generic;
using LoginNavigation.Models;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class MatchesPage : ContentPage
    {
        int matchIndex = 0;
        List<User> allUsers;
        public MatchesPage()
        {
            InitializeComponent();
            TestDatabase();
            NavigationPage.SetHasBackButton(this, false);
        }
        public async void TestDatabase()
        {
            if (allUsers == null)
            {
                allUsers = await App.Database.GetUsersAsync();
                allUsers = allUsers.Where(x => x.Role == "Mentor").ToList();

                //How many interests the user has in common with a mentor.
                int[] interestHits = new int[allUsers.Count];
                //IDs of the mentors. The indexes of interestHits and IDs
                //are shared for easy access and ordering of the allUsers list.
                int[] IDs = new int[allUsers.Count];
                Dictionary<int, int> dict = new Dictionary<int, int>();

                //String used to hold the interests of the current user
                //in the loop
                List<String> tempInterests;
                int hits;

                for (int i = 0; i < allUsers.Count; i++)
                {
                    hits = 0;
                    tempInterests = new List<String>(allUsers[i].Interests.Split('^'));
                    for (int j = 0; j < tempInterests.Count; j++)
                    {
                        if (App.UserLoggedIn.Interests.Contains(tempInterests[j]))
                            hits++;
                    }
                    dict.Add(allUsers[i].ID, hits);
                }

                allUsers.Sort((x, y) => dict[x.ID] > dict[y.ID] ? -1 : dict[x.ID] < dict[y.ID] ? 1 : 0);
            }
                
            if (matchIndex == 0)
                backButton.IsVisible = false;
            if (matchIndex == allUsers.Count - 1)
                nextButton.IsVisible = false;

            matchImage.Source = ImageSource.FromStream(() => new MemoryStream(allUsers[matchIndex].ProfilePic));
            matchName.Text = allUsers[matchIndex].FirstName + " " + allUsers[matchIndex].LastName;

            if (!String.IsNullOrEmpty(allUsers[matchIndex].Description))
                matchDescription.Text = allUsers[matchIndex].Description;

            List<String> interests = new List<String>(allUsers[matchIndex].Interests.Split('^'));
            for (int i = 0; i < interests.Count; i++)
                matchInterests.Text += interests[i] + ", ";
            if (!String.IsNullOrEmpty(matchInterests.Text))
                matchInterests.Text = matchInterests.Text.Remove(matchInterests.Text.Length - 2);


        }
        async void OnNextButtonClicked(object sender, EventArgs e)
        {
            if (matchIndex < allUsers.Count - 1)
            {
                MatchesPage nextPage = new MatchesPage();
                nextPage.allUsers = allUsers;
                nextPage.matchIndex = matchIndex + 1;
                await Navigation.PushAsync(nextPage);
            }
        }

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            if (matchIndex > 0)
            {
                await Navigation.PopAsync();
            }
        }
    }
}
