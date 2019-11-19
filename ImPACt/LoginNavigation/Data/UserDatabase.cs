using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using LoginNavigation.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;

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

        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }


        public Task<User> GetUserAsync(int id)
        {
            return _database.Table<User>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<User> GetUserAsync(string email)
        {
            return _database.Table<User>()
                            .Where(i => i.Email == email)
                            .FirstOrDefaultAsync();
        }

        public Task<User> GetUserAsync(string email, string password)
        {
            return _database.Table<User>()
                            .Where(i => i.Email == email && i.Password == password)
                            .FirstOrDefaultAsync();
        }

        public Task<User> GetUserAsynch(string email)
        {
            return _database.Table<User>()
                            .Where(i => i.Email == email)
                            .FirstOrDefaultAsync();
        }

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

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
    }
}