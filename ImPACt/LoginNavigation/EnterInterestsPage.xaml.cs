using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LoginNavigation
{

    public partial class EnterInterestsPage : ContentPage
    {

        List<String> interests;
        Label interestsLabel0;
        public EnterInterestsPage()
        {
            InitializeComponent();
            this.BindingContext = new InterestsPageViewModel();
            interests = new List<String>(App.UserLoggedIn.Interests.Split('^'));
        }

        public void EnterInterestsPageCS()
        {
            var picker = new Picker { Title = "Select a Subject of Interest:", TitleColor = Color.Red };
            picker.SetBinding(Picker.ItemsSourceProperty, "Interests");
            picker.SetBinding(Picker.SelectedItemProperty, "SelectedInterest");
            picker.ItemDisplayBinding = new Binding("Subject");

            interestsLabel0 = new Label { HorizontalOptions = LayoutOptions.Center };
            interestsLabel0.SetBinding(Label.TextProperty, "SelectedInterest.SubjectInterests[0]");
            interestsLabel0.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel1 = new Label { HorizontalOptions = LayoutOptions.Center };
            interestsLabel1.SetBinding(Label.TextProperty, "SelectedInterest.SubjectInterests[1]");
            interestsLabel1.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel2 = new Label { HorizontalOptions = LayoutOptions.Center };
            interestsLabel2.SetBinding(Label.TextProperty, "SelectedInterest.SubjectInterests[2]");
            interestsLabel2.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel3 = new Label { HorizontalOptions = LayoutOptions.Center };
            interestsLabel3.SetBinding(Label.TextProperty, "SelectedInterest.SubjectInterests[3]");
            interestsLabel3.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel4 = new Label { HorizontalOptions = LayoutOptions.Center };
            interestsLabel4.SetBinding(Label.TextProperty, "SelectedInterest.SubjectInterests[4]");
            interestsLabel4.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel5 = new Label { HorizontalOptions = LayoutOptions.Center };
            interestsLabel5.SetBinding(Label.TextProperty, "SelectedInterest.SubjectInterests[5]");
            interestsLabel5.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel6 = new Label { HorizontalOptions = LayoutOptions.Center };
            interestsLabel6.SetBinding(Label.TextProperty, "SelectedInterest.SubjectInterests[6]");
            interestsLabel6.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel7 = new Label { HorizontalOptions = LayoutOptions.Center };
            interestsLabel7.SetBinding(Label.TextProperty, "SelectedInterest.SubjectInterests[7]");
            interestsLabel7.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel8 = new Label { HorizontalOptions = LayoutOptions.Center };
            interestsLabel8.SetBinding(Label.TextProperty, "SelectedInterest.SubjectInterests[8]");
            interestsLabel8.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            var interestsLabel9 = new Label { HorizontalOptions = LayoutOptions.Center };
            interestsLabel9.SetBinding(Label.TextProperty, "SelectedInterest.SubjectInterests[9]");
            interestsLabel9.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

            Switch interestsSwitch0 = new Switch
            {
                IsToggled = false,
                OnColor = Color.Blue,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            if (interests.Contains(interestsLabel0.Text))
            {
                interestsSwitch0.IsToggled = true;
            }
            interestsSwitch0.Toggled += interestsSwitch0_Toggled;
            /*var interestsCheckBox0 = new CheckBox { VerticalOptions = LayoutOptions.Center };
            
            interestsCheckBox0.CheckedChanged += (sender, e) =>
            {
                if (e.Value)
                {
                    interests.Add(interestsLabel0.Text);
                }
                else
                {
                    interests.Remove(interestsLabel0.Text);
                }
            };

            var interestsCheckBox1 = new CheckBox { VerticalOptions = LayoutOptions.Center };
            if (interests.Contains(interestsLabel1.Text))
            {
                interestsCheckBox1.IsChecked = true;
            }
            interestsCheckBox1.CheckedChanged += (sender, e) =>
            {
                if (e.Value)
                {
                    interests.Add(interestsLabel1.Text);
                }
                else
                {
                    interests.Remove(interestsLabel1.Text);
                }
            };

            CheckBox interestsCheckBox2 = new CheckBox { VerticalOptions = LayoutOptions.Center };
            if (interests.Contains(interestsLabel2.Text))
            {
                interestsCheckBox2.IsChecked = true;
            }
            interestsCheckBox2.CheckedChanged += (sender, e) =>
            {
                if (e.Value)
                {
                    interests.Add(interestsLabel2.Text);
                }
                else
                {
                    interests.Remove(interestsLabel2.Text);
                }
            };

            CheckBox interestsCheckBox3 = new CheckBox { VerticalOptions = LayoutOptions.Center };
            if (interests.Contains(interestsLabel3.Text))
            {
                interestsCheckBox3.IsChecked = true;
            }
            interestsCheckBox3.CheckedChanged += (sender, e) =>
            {
                if (e.Value)
                {
                    interests.Add(interestsLabel3.Text);
                }
                else
                {
                    interests.Remove(interestsLabel3.Text);
                }
            };

            CheckBox interestsCheckBox4 = new CheckBox { VerticalOptions = LayoutOptions.Center };
            if (interests.Contains(interestsLabel4.Text))
            {
                interestsCheckBox4.IsChecked = true;
            }
            interestsCheckBox4.CheckedChanged += (sender, e) =>
            {
                if (e.Value)
                {
                    interests.Add(interestsLabel4.Text);
                }
                else
                {
                    interests.Remove(interestsLabel4.Text);
                }
            };

            CheckBox interestsCheckBox5 = new CheckBox { VerticalOptions = LayoutOptions.Center };
            if (interests.Contains(interestsLabel5.Text))
            {
                interestsCheckBox5.IsChecked = true;
            }
            interestsCheckBox5.CheckedChanged += (sender, e) =>
            {
                if (e.Value)
                {
                    interests.Add(interestsLabel5.Text);
                }
                else
                {
                    interests.Remove(interestsLabel5.Text);
                }
            };

            CheckBox interestsCheckBox6 = new CheckBox { VerticalOptions = LayoutOptions.Center };
            if (interests.Contains(interestsLabel6.Text))
            {
                interestsCheckBox6.IsChecked = true;
            }
            interestsCheckBox6.CheckedChanged += (sender, e) =>
            {
                if (e.Value)
                {
                    interests.Add(interestsLabel6.Text);
                }
                else
                {
                    interests.Remove(interestsLabel6.Text);
                }
            };

            CheckBox interestsCheckBox7 = new CheckBox { VerticalOptions = LayoutOptions.Center };
            if (interests.Contains(interestsLabel7.Text))
            {
                interestsCheckBox7.IsChecked = true;
            }
            interestsCheckBox7.CheckedChanged += (sender, e) =>
            {
                if (e.Value)
                {
                    interests.Add(interestsLabel7.Text);
                }
                else
                {
                    interests.Remove(interestsLabel7.Text);
                }
            };

            CheckBox interestsCheckBox8 = new CheckBox { VerticalOptions = LayoutOptions.Center };
            if (interests.Contains(interestsLabel8.Text))
            {
                interestsCheckBox8.IsChecked = true;
            }
            interestsCheckBox8.CheckedChanged += (sender, e) =>
            {
                if (e.Value)
                {
                    interests.Add(interestsLabel8.Text);
                }
                else
                {
                    interests.Remove(interestsLabel8.Text);
                }
            };

            CheckBox interestsCheckBox9 = new CheckBox { VerticalOptions = LayoutOptions.Center };
            if (interests.Contains(interestsLabel9.Text))
            {
                interestsCheckBox9.IsChecked = true;
            }
            interestsCheckBox9.CheckedChanged += (sender, e) =>
            {
                if (e.Value)
                {
                    interests.Add(interestsLabel9.Text);
                }
                else
                {
                    interests.Remove(interestsLabel9.Text);
                }
            };*/
            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Margin = new Thickness(20, 35, 20, 20),
                    Children =
                    {
                        new Label { Text = "Interests", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
                        
                        interestsLabel0,
                        //interestsCheckBox0,
                        interestsLabel1,
                        //interestsCheckBox1,
                        interestsLabel2,
                        //interestsCheckBox2,
                        interestsLabel3,
                        //interestsCheckBox3,
                        interestsLabel4,
                        //interestsCheckBox4,
                        interestsLabel5,
                        //interestsCheckBox5,
                        interestsLabel6,
                        //interestsCheckBox6,
                        interestsLabel7,
                        //interestsCheckBox7,
                        interestsLabel8,
                        //interestsCheckBox8,
                        interestsLabel9//,
                        //interestsCheckBox9
					}
                }
            };

            BindingContext = new InterestsPageViewModel();
        }

        /*public void EnterPressed(object sender, EventArgs e)
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
        }*/

        private void interestsSwitch0_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                interests.Add(interestsLabel0.Text);
            }
            else
            {
                interests.Remove(interestsLabel0.Text);
            }
        }
        public async void OnNextButtonClicked(object sender, EventArgs e)
        {
            /*if(interests.Count > 10)
            {
                //Error here to limit # of interests
            }*/
            App.UserLoggedIn.Interests = String.Join("^", interests.ToArray());
            await App.Database.SaveUserAsync(App.UserLoggedIn);
            await Navigation.PushAsync(new WriteDescriptionPage());
        }
    }
}
