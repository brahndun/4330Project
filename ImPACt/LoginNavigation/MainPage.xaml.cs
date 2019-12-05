using System;
using Xamarin.Forms;

namespace LoginNavigation
{
    
    public partial class MainPage : TabbedPage
    {

        public MatchesPage currentMatchesPage { get; set; }
        //Constructor which sets the current view to be a MatchesPage, but leaves the navigation bar at the bottom of the app.
        public MainPage()
        {
            InitializeComponent();

            App.tabbedPage = this;
            currentMatchesPage = curMatchPage;
            
            this.BarBackgroundColor = Color.FromRgb(60, 133, 186);
            this.UnselectedTabColor = Color.FromRgb(40,40,40);
            this.SelectedTabColor = Color.FromRgb(240,240,240);
        }
    }
}
