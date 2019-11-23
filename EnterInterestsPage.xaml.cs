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

        public EnterInterestsPageCS()
		{
			var picker = new Picker { Title = "Select a Subject of Interest:", TitleColor = Color.Red };
			picker.SetBinding(Picker.ItemsSourceProperty, "Interests");
			picker.SetBinding(Picker.SelectedItemProperty, "SelectedInterest");
			picker.ItemDisplayBinding = new Binding("Subject");

			var interestsLabel0 = new Label { HorizontalOptions = LayoutOptions.Center };
			nameLabel.SetBinding(Label.TextProperty, "SelectedInterest.Interests[0]");
			nameLabel.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel1 = new Label { HorizontalOptions = LayoutOptions.Center };
			nameLabel.SetBinding(Label.TextProperty, "SelectedInterest.Interests[1]");
			nameLabel.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel2 = new Label { HorizontalOptions = LayoutOptions.Center };
			nameLabel.SetBinding(Label.TextProperty, "SelectedInterest.Interests[2]");
			nameLabel.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel3 = new Label { HorizontalOptions = LayoutOptions.Center };
			nameLabel.SetBinding(Label.TextProperty, "SelectedInterest.Interests[3]");
			nameLabel.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel4 = new Label { HorizontalOptions = LayoutOptions.Center };
			nameLabel.SetBinding(Label.TextProperty, "SelectedInterest.Interests[4]");
			nameLabel.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel5 = new Label { HorizontalOptions = LayoutOptions.Center };
			nameLabel.SetBinding(Label.TextProperty, "SelectedInterest.Interests[5]");
			nameLabel.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel6 = new Label { HorizontalOptions = LayoutOptions.Center };
			nameLabel.SetBinding(Label.TextProperty, "SelectedInterest.Interests[6]");
			nameLabel.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel7 = new Label { HorizontalOptions = LayoutOptions.Center };
			nameLabel.SetBinding(Label.TextProperty, "SelectedInterest.Interests[7]");
			nameLabel.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel8 = new Label { HorizontalOptions = LayoutOptions.Center };
			nameLabel.SetBinding(Label.TextProperty, "SelectedInterest.Interests[8]");
			nameLabel.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel9 = new Label { HorizontalOptions = LayoutOptions.Center };
			nameLabel.SetBinding(Label.TextProperty, "SelectedInterest.Interests[9]");
			nameLabel.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

			Content = new ScrollView
			{
				Content = new StackLayout
				{
					Margin = new Thickness(20,35,20,20),
					Children =
					{
						new Label { Text = "Interests", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
						picker,
						interestsLabel0,
                        interestsLabel1,
                        interestsLabel2,
                        interestsLabel3,
                        interestsLabel4,
                        interestsLabel5,
                        interestsLabel6,
                        interestsLabel7,
                        interestsLabel8,
                        interestsLabel9
					}
				}
			};

			BindingContext = new InterestsPageViewModel();
		}

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

        public async void OnNextButtonClicked(object sender, EventArgs e)
        {
            App.UserLoggedIn.Interests = String.Join("^", interests.ToArray());
            await App.Database.SaveUserAsync(App.UserLoggedIn);
            await Navigation.PushAsync(new WriteDescriptionPage());
        }
    }
}
