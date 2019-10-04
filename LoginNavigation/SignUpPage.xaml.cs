using System;
using System.Linq;
using Xamarin.Forms;

namespace LoginNavigation
{
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();
		}

		async void OnSignUpButtonClicked (object sender, EventArgs e)
		{
            var user = new User() {
                Password = passwordEntry.Text,
                Email = emailEntry.Text.ToLower()
			};

			// Sign up logic goes here

			var signUpSucceeded = AreDetailsValid (user);
			if (signUpSucceeded) {
				var rootPage = Navigation.NavigationStack.FirstOrDefault ();
				if (rootPage != null) {
                    RegisteredUsers.registeredUsers.Add(user);
					App.IsUserLoggedIn = true;
					Navigation.InsertPageBefore (new MainPage (), Navigation.NavigationStack.First ());
					await Navigation.PopToRootAsync ();
				}
			} else {
				messageLabel.Text = "Sign up failed";
			}
		}

		bool AreDetailsValid (User user)
		{
			return (!string.IsNullOrWhiteSpace (user.Email) && !string.IsNullOrWhiteSpace (user.Password) && !string.IsNullOrWhiteSpace (user.Email) && user.Email.Contains ("@") && user.Password == passwordRepeatEntry.Text && RegisteredUsers.registeredUsers.FindIndex(a => a.Email.ToLower() == user.Email.ToLower()) == -1);
		}
	}
}
