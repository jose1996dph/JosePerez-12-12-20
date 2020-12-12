using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Miniproject.Services
{
    public class TaskStore : IDataStore<Models.Task>
    {
        private SQLiteAsyncConnection db;
        public TaskStore()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Miniproject.db3");
            db = new SQLiteAsyncConnection(path);
            db.CreateTableAsync<Models.Task>();
        }

        public async Task<bool> AddAsync(Models.Task item)
        {
            return await db.InsertAsync(item) > 0;
        }

        public async Task<bool> UpdateAsync(Models.Task item)
        {
            return await db.UpdateAsync(item) > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await db.DeleteAsync<Models.Task>(id) > 0;
        }

        public async Task<Models.Task> GetAsync(string id)
        {
            return await db.GetAsync<Models.Task>(id);
        }

        public async Task<IEnumerable<Models.Task>> GetAllAsync()
        {
            return await db.Table<Models.Task>().ToListAsync();
        }
    }
}