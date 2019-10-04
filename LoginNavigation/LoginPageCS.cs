using System;
using Xamarin.Forms;

namespace LoginNavigation
{
	public class LoginPageCS : ContentPage
	{
		Entry usernameEntry, passwordEntry;
		Label messageLabel;

		public LoginPageCS ()
		{
			var toolbarItem = new ToolbarItem {
				Text = "Poopshit"
			};
			toolbarItem.Clicked += OnSignUpButtonClicked;
			ToolbarItems.Add (toolbarItem);

			messageLabel = new Label ();
			usernameEntry = new Entry {
				Placeholder = "usdgdg"	
			};
			passwordEntry = new Entry {
				IsPassword = true
			};
			var loginButton = new Button {
				Text = "gdain"
			};
			loginButton.Clicked += OnLoginButtonClicked;

			Title = "Loooppie";
			Content = new StackLayout { 
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					new Label { Text = "Userdgsname" },
					usernameEntry,
					new Label { Text = "Passsdgword" },
					passwordEntry,
					loginButton,
					messageLabel
				}
			};
		}

		async void OnSignUpButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new SignUpPageCS ());
		}

		async void OnLoginButtonClicked (object sender, EventArgs e)
		{
			var user = new User {
				Email = emailEntry.Text,
				Password = passwordEntry.Text
			};

			var isValid = AreCredentialsCorrect (user);
			if (isValid) {
				App.IsUserLoggedIn = true;
				Navigation.InsertPageBefore (new MainPageCS (), this);
				await Navigation.PopAsync ();
			} else {
				messageLabel.Text = "Loginsdg failed";
				passwordEntry.Text = string.Empty;
			}
		}

		bool AreCredentialsCorrect (User user)
		{
			return user.Username == Constants.Username && user.Password == Constants.Password;
		}
	}
}


