using System.Collections;
using SQLite;
using System.Collections.Generic;

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
        public int Age { get; set; }
        public string University { get; set; }
        public List<string> Interests;
    }
}
