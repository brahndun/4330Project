using System.Collections.Generic;

namespace LoginNavigation
{
    public class InterestsPageViewModel : ViewModelBase
    {
        public IList<Interest> Interests { get { return InterestsData.Interests; } }

        Interest selectedInterest;
        public Interest SelectedInterest
        {
            get { return selectedInterest; }
            set
            {
                if (selectedInterest != value)
                {
                    selectedInterest = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
