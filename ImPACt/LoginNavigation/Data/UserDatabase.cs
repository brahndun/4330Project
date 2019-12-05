using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using LoginNavigation.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;

//The SQLite database for this app that holds user information
namespace LoginNavigation.Data
{
    public class UserDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public UserDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        //Returns a list of all the users in the database
        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }


        //Gets a user from the database with an ID matching the given id
        public Task<User> GetUserAsync(int id)
        {
            return _database.Table<User>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        //Gets a user from the database with an email matching the given email
        public Task<User> GetUserAsync(string email)
        {
            return _database.Table<User>()
                            .Where(i => i.Email == email)
                            .FirstOrDefaultAsync();
        }

        //Get a user from the database with email and password matching the given email and password
        public Task<User> GetUserAsync(string email, string password)
        {
            return _database.Table<User>()
                            .Where(i => i.Email == email && i.Password == password)
                            .FirstOrDefaultAsync();
        }

        //This function shouldn't exist but it shouldn't be deleted until
        //after the presentation just in case it breaks something
        public Task<User> GetUserAsynch(string email)
        {
            return _database.Table<User>()
                            .Where(i => i.Email == email)
                            .FirstOrDefaultAsync();
        }

        //Saves a user object to the database
        public Task<int> SaveUserAsync(User user)
        {
            if (user.ID != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }

        //Deletes a user object from the database
        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
    }
}