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

            //Loads the user's current information into the entry fields.
            firstNameEntry.Text = App.UserLoggedIn.FirstName;
            lastNameEntry.Text = App.UserLoggedIn.LastName;
            stateEntry.Text = App.UserLoggedIn.State;
            cityEntry.Text = App.UserLoggedIn.City;
            phoneEntry.Text = App.UserLoggedIn.Phone;
            universityEntry.Text = App.UserLoggedIn.University;
            birthEntry.Text = App.UserLoggedIn.Birth;
            if (App.UserLoggedIn.Gender != null)
                genderEntry.SelectedItem = App.UserLoggedIn.Gender;
            if (App.UserLoggedIn.Role != null)
                roleEntry.SelectedItem = App.UserLoggedIn.Role;

        }

        //When the next button is clicked, updates the user's information if the information is valid
        async void OnNextButtonClicked(object sender, EventArgs e)
        {
            //Checks to ensure all information entered is valid
            if (isFormValid())
            {
                //Updates all the user's information
                User u = App.UserLoggedIn; //shorthand
                u.FirstName = firstNameEntry.Text;
                u.LastName = lastNameEntry.Text;
                u.State = stateEntry.Text;
                u.City = cityEntry.Text;
                u.Gender = genderEntry.SelectedIndex == 0 ? "Male" : genderEntry.SelectedIndex == 1 ? "Female" : "Other";
                u.Role = roleEntry.SelectedIndex == 0 ? "Mentor" : "Mentee";
                u.Birth = birthEntry.Text;
                u.Phone = phoneEntry.Text;
                u.University = universityEntry.Text;
                await App.Database.SaveUserAsync(u);
                await Navigation.PushAsync(new EnterInterestsPage());
            }
            else
            {
                messageLabel.Text = "Please make sure all the information below is correct.";
            }
        }

        bool isFormValid()
        {
            //Used when determining if the birth date given is in mm/dd/yyyy format
            DateTime dDate;
            //The boolean that gets returned at the end of this function. If any form
            //has incorrect information, valid will be turned to false.
            bool valid = true;


            if (String.IsNullOrEmpty(firstNameEntry.Text))
                valid = false;
            else if (String.IsNullOrEmpty(lastNameEntry.Text))
                valid = false;
            else if (firstNameEntry.Text.Any(char.IsDigit))
                valid = false;
            else if (lastNameEntry.Text.Any(char.IsDigit))
                valid = false;
            else if (String.IsNullOrEmpty(cityEntry.Text))
                valid = false;
            else if (String.IsNullOrEmpty(stateEntry.Text))
                valid = false;
            else if (String.IsNullOrEmpty(universityEntry.Text))
                valid = false;
            else if (String.IsNullOrEmpty(phoneEntry.Text))
                valid = false;
            else if (String.IsNullOrEmpty(birthEntry.Text))
                valid = false;
            else if (!DateTime.TryParse(birthEntry.Text, out dDate))
                valid = false;
            else if (genderEntry.SelectedItem == null)
                valid = false;
            else if (roleEntry.SelectedItem == null)
                valid = false;
            return valid;
        }
    }
}
