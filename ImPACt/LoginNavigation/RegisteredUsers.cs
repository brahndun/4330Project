using System.Collections.Generic;

namespace LoginNavigation
{
    public class RegisteredUsers
    {
        public static List<User> registeredUsers = new List<User>
        {
            new User()
            {
                Email = "datki11@lsu.edu",
                Password = "password" //this is not my real password don't even try
            },
            new User()
            {
                Email = "person@lsu.edu",
                Password = "wordpass"
            },
            new User()
            {
                Email = "john@lsu.edu",
                Password = "beansoup"
            }
        };
    }
}
