using System.Collections.Generic;

namespace LoginNavigation
{
    public class InterestsPageViewModel : ViewModelBase
    {
        public IList<Interests> Interests { get { return InterestsData.interests; } }

        Intersts selectedInterest;
        public Interests SelectedInterest
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
