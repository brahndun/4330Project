using System;
using System.IO;
using Xamarin.Forms;
using LoginNavigation.Data;
using LoginNavigation.Models;

namespace LoginNavigation
{
    public class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public static User UserLoggedIn { get; set; }
        static UserDatabase database;

        //A reference to the main page, which is a tabbed page containing 4 other pages
        public static MainPage tabbedPage { get; set; }

        public static UserDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Users3.db3"));

                    
                }
                return database;
            }
        }

        public App()
        {
            if (!IsUserLoggedIn)
            {
                var navPage = new NavigationPage(new LoginPage());
                navPage.BarBackgroundColor = Color.FromRgb(153, 255, 204);
                MainPage = navPage;
            }
            else
            {
                MainPage = new NavigationPage(new LoginNavigation.MainPage());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}



