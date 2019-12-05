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
        //The index of the current match the user is viewing
        static int matchIndex;

        //A list containing all the user's matches
        static List<User> allUsers;

        //Set to true when a match has just been removed from the match list.
        //When it's true, the next and back buttons operate a bit differently
        bool justRemovedMatch = false;

        public MatchesPage()
        {
            InitializeComponent();
            LoadMatches();
            NavigationPage.SetHasBackButton(this, false);
            
        }
        public async void LoadMatches()
        {
            if (allUsers == null)
            {
                allUsers = await App.Database.GetUsersAsync();
                //Only find mentors to match with if the user is a mentee.
                if (App.UserLoggedIn.Role == "Mentee")
                    allUsers = allUsers.Where(x => x.Role == "Mentor").ToList();
                //Only find mentees to match with if the user is a mentor.
                else
                    allUsers = allUsers.Where(x => x.Role == "Mentee").ToList();

                //Remove all users the current user has already accepted to match with
                if (!String.IsNullOrEmpty(App.UserLoggedIn.Associates))
                {
                    List<String> myAssociates = new List<String>(App.UserLoggedIn.Associates.Split('^'));
                    //Removes all null values from the associates array
                    myAssociates = myAssociates.Where(x => !String.IsNullOrEmpty(x)).ToList();
                    allUsers = allUsers.Where(x => !myAssociates.Contains(allUsers[matchIndex].ID.ToString())).ToList();
                }

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
            if (matchIndex >= allUsers.Count - 1)
                nextButton.IsVisible = false;

            //Checks to see if the current match has already been sent a request by the user.
            //If so, then disable the "Request to match" button
            if (!String.IsNullOrEmpty(App.UserLoggedIn.MatchRequestsSent))
            {
                //Changes the string of IDs stored in the logged in user's MatchRequestsSent property
                //and changes it to a list of IDs
                List<String> matchRequestsSent = new List<String>(App.UserLoggedIn.MatchRequestsSent.Split('^'));

                if (matchRequestsSent.Contains(allUsers[matchIndex].ID.ToString()))
                    ChangeRequestButtonToRequestSent();
            }

            //Checks to see if the current match has sent a request to the logged in user.
            //If so, change  "request to connect" button to "accept request"
            if (!String.IsNullOrEmpty(App.UserLoggedIn.MatchRequestsReceived))
            {
                //Changes the string of IDs stored in the logged in user's MatchRequestsSent property
                //and changes it to a list of IDs
                List<String> matchRequestsReceived = new List<String>(App.UserLoggedIn.MatchRequestsReceived.Split('^')).Where(x => !String.IsNullOrEmpty(x)).ToList();

                if (matchRequestsReceived.Contains(allUsers[matchIndex].ID.ToString()))
                    ChangeRequestButtonToAcceptRequest();
            }



            if (allUsers.Count > 0)
            {
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

            else
            {
                if (App.UserLoggedIn.Role == "Mentor")
                    matchName.Text = "No valid mentees in the system";
                else
                    matchName.Text = "No valid mentors in the system";
            }


        }
        async void OnNextButtonClicked(object sender, EventArgs e)
        {
            //Since Xamarin decided that double tapping a tab pops back to the root
            //of that tab's navigation page WITHOUT any kind of event, this code makes sure
            //the matchIndex doesn't get screwed up.
            if (matchName.Text != allUsers[matchIndex].FullName && !justRemovedMatch)
                matchIndex = 0;


            if (matchIndex < allUsers.Count - 1 || justRemovedMatch)
            {
                if (!justRemovedMatch)
                    matchIndex += 1;
               
                MatchesPage nextPage = new MatchesPage();
                
                await Navigation.PushAsync(nextPage);

                if (justRemovedMatch)
                {
                    App.tabbedPage.currentMatchesPage = nextPage;
                    Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count() - 2]);
                }

                    
                    
            }
        }

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            if (matchIndex > 0)
            {
                matchIndex--;
                await Navigation.PopAsync();
            }
        }

        async void OnRequestButtonClicked(object sender, EventArgs e)
        {
            ChangeRequestButtonToRequestSent();
            //Adds the request to the user's list of sent match requests
            App.UserLoggedIn.MatchRequestsSent += allUsers[matchIndex].ID.ToString() + '^';
            //Adds the request to the other user's list of match requests received
            allUsers[matchIndex].MatchRequestsReceived += App.UserLoggedIn.ID.ToString() + '^';
            //Updates the users into the database
            await App.Database.SaveUserAsync(App.UserLoggedIn);
            await App.Database.SaveUserAsync(allUsers[matchIndex]);
        }

        void ChangeRequestButtonToRequestSent()
        {
            bottomGrid.Children.Remove(requestButton);
            bottomGrid.Children.Add(new Label() {
                Text = "Request sent",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 0);
        }

        void ChangeRequestButtonToAcceptRequest()
        {
            bottomGrid.Children.Remove(requestButton);
            Button button = new Button()
            {
                Text = "Accept Request",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.Green,
                CornerRadius = 16,
                Padding = new Thickness(15, 0, 15, 0),
                FontAttributes = FontAttributes.Bold
            };
            button.Clicked += AcceptMatchRequest;
            bottomGrid.Children.Add(button, 1, 0);
            requestButton = button;
        }

        public async void AcceptMatchRequest(object sender, EventArgs e)
        {

            bottomGrid.Children.Remove(requestButton);
            bottomGrid.Children.Add(new Label()
            {
                Text = "Request accepted",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 0);

            //Removes the request from the logged in user's list of received match requests
            App.UserLoggedIn.MatchRequestsReceived = String.Join("^", App.UserLoggedIn.MatchRequestsReceived.Split('^').Where(x => x != allUsers[matchIndex].ID.ToString()).ToArray());
            //Removes the request from the other user's list of sent requests
            allUsers[matchIndex].MatchRequestsSent = String.Join("^", allUsers[matchIndex].MatchRequestsSent.Split('^').Where(x => x != App.UserLoggedIn.ID.ToString()).ToArray());
            //Since the two users have accepted to be matched with each other,
            //add their ID's to each other's associates list
            App.UserLoggedIn.Associates += allUsers[matchIndex].ID.ToString() + "^";
            allUsers[matchIndex].Associates += App.UserLoggedIn.ID.ToString() + "^";
            
            //Saves the changes made to the users to the database
            await App.Database.SaveUserAsync(App.UserLoggedIn);
            await App.Database.SaveUserAsync(allUsers[matchIndex]);

            allUsers.RemoveAt(matchIndex);
            justRemovedMatch = true;

            //DEBUG
            Console.WriteLine("Associates: " + App.UserLoggedIn.Associates);



        }

        //Go to the match page of the specified user
        public async void GoToUser(User u)
        {
            //Index of the user within the allUsers list
            int index;
            index = allUsers.FindIndex(x => x.ID == u.ID);

            //Navigates to the user's match page while popping and pushing any
            //inbetween pages to and from the navigation stack
            if (index - matchIndex > 0)
            {
                while (matchIndex < index)
                {
                    if (!justRemovedMatch)
                        matchIndex += 1;

                    MatchesPage nextPage = new MatchesPage();

                    Navigation.PushAsync(nextPage);

                    if (justRemovedMatch)
                    {
                        App.tabbedPage.currentMatchesPage = nextPage;
                        Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count() - 2]);
                    }
                }
            }
            if (index - matchIndex < 0)
            {
                while (matchIndex > index)
                {
                    matchIndex--;
                    await Navigation.PopAsync();
                }
            }

        }

        public void Reset()
        {
            matchIndex = 0;
            allUsers = null;
        }
    }
}
