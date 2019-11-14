using System;
using System.Collections.Generic;
using LoginNavigation.Models;
using System.IO;
using System.Linq;

using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class MakeProfilePage : ContentPage
    {
        public MakeProfilePage()
        {
            InitializeComponent();
        }

        async void OnNextButtonClicked(object sender, EventArgs e)
        {
            User u = App.UserLoggedIn; //shorthand
            u.FirstName = firstNameEntry.Text;
            u.LastName = lastNameEntry.Text;
            u.State = stateEntry.Text;
            u.City = cityEntry.Text;
            u.Gender = genderEntry.SelectedIndex == 0 ? "Male" : genderEntry.SelectedIndex == 1 ? "Female" : "Other";
            u.Role = roleEntry.SelectedIndex == 0 ? "Mentor" : "Mentee";
            u.Age = Convert.ToInt32(ageEntry.Text);
            u.Phone = phoneEntry.Text;
            u.University = universityEntry.Text;
            await App.Database.SaveNoteAsync(u);
            await Navigation.PushAsync(new EnterInterestsPage());
        }
    }
}
