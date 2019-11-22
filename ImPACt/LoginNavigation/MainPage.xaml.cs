using System;
using Xamarin.Forms;

namespace LoginNavigation
{
    
    public partial class MainPage : TabbedPage
    {

        public MatchesPage currentMatchesPage { get; set; }
        public MainPage()
        {
            InitializeComponent();

            App.tabbedPage = this;
            currentMatchesPage = curMatchPage;
            
            this.BarBackgroundColor = Color.FromRgb(89, 189, 148);
            this.UnselectedTabColor = Color.FromRgb(80, 80, 80);
            this.SelectedTabColor = Color.FromRgb(19, 51, 255);
        }
    }
}
