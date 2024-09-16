using MyFirstMAUIApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMAUIApp.Services
{
    public class UserService : IUserService
    {
        private SQLiteAsyncConnection _connection;
        public UserService()
        {
            SetupDatabase();
        }

        public Task<int> AddAsync(User user)
        {
           return _connection.InsertAsync(user);
        }

        public Task<int> DeleteAsync(User user)
        {
            return _connection.DeleteAsync(user);
        }

        public Task<List<User>> GetAsync()
        {
           return _connection.Table<User>().ToListAsync();
        }

        public Task<int> UpdateAsync(User user)
        {
            return _connection.UpdateAsync(user);
        }

        private async void SetupDatabase()
        {
            if(_connection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "userDB");
                _connection = new SQLiteAsyncConnection(dbPath);
                await _connection.CreateTableAsync<User>();
            }
        }
    }
}
