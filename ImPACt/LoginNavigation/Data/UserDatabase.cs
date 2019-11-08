using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using LoginNavigation.Models;

namespace LoginNavigation.Data
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public NoteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetNotesAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetNoteAsync(int id)
        {
            return _database.Table<User>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(User user)
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

        public Task<int> DeleteNoteAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
    }
}