using System.Collections;
using SQLite;
using System.Collections.Generic;
using SQLiteNetExtensions;
using Plugin.Media;
using System.Linq;
using Plugin.Media.Abstractions;
using System.ComponentModel;

namespace LoginNavigation.Models
{
    public class User : INotifyPropertyChanged
    {
        //Unique identifier for each user
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        //The email the user is registered with
        public string Email { get; set; }

        //The user's password, used when they log in
        public string Password { get; set; }

        //Personal information about the user
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public string Birth { get; set; }
        public string University { get; set; }

        //A description the user writes to describe theirself.
        public string Description { get; set; }
        //A list of the user's interests, separated by the delimiter ^
        public string Interests { get; set; }
        //A list of IDs that correspond to users that this user has sent match requests to
        private string matchRequestsSent;
        public string MatchRequestsSent { get { return matchRequestsSent; } set { matchRequestsSent = value; OnPropertyChanged("matchRequestsSent"); } }
        //A list of user IDs that have sent a match request to this user
        private string matchRequestsReceived;
        public string MatchRequestsReceived { get { return matchRequestsReceived; } set { matchRequestsReceived = value; OnPropertyChanged("matchRequestsReceived"); } }
        //A list of user IDs corresponding to users this user has successfully connected/paired with
        private string associates = string.Empty;
        public string Associates { get { return associates; } set { associates = value; OnPropertyChanged("Associates"); } }

        //The user's profile pic, saved as an array of bytes.
        public byte[] ProfilePic { get; set; } = null;

        //Returns this user's first name and last name, making up their full name
        public string FullName { get { return this.FirstName + " " + this.LastName; } }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        //Function used to determine if one user equals another
        public override bool Equals(object obj)
        {
            User user = (User)obj;
            return user.ID == ID;
        }

    }
}
