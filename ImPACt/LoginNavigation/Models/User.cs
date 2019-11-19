using System.Collections;
using SQLite;
using System.Collections.Generic;
using SQLiteNetExtensions;
using Plugin.Media;
using System.Linq;
using Plugin.Media.Abstractions;

namespace LoginNavigation.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public string Birth { get; set; }
        public string University { get; set; }
        public string Description { get; set; }
        //A list of the user's interests, separated by the delimiter ^
        public string Interests { get; set; }

        //The user's profile pic, saved as an array of bytes.
        public byte[] ProfilePic { get; set; } = null;
    }
}
