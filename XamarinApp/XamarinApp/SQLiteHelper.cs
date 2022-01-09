using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinApp.Models;

namespace XamarinApp
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<User>().Wait();
            db.CreateTableAsync<Inventory>().Wait();

        }
        public Task<List<User>> GetUsersAsync()
        {
            return db.Table<User>().ToListAsync();
        }

        public Task<List<Inventory>> GeInventoriesAsync()
        {
            return db.Table<Inventory>().ToListAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.UserID != 0)
            {
                return db.UpdateAsync(user);
            }
            else
            {
                return db.InsertAsync(user);
            }
        }

        public Task<int> SaveInventoryAsync(Inventory inventory)
        {
            if (inventory.InventoryID != 0)
            {
                return db.UpdateAsync(inventory);
            }
            else
            {
                return db.InsertAsync(inventory);
            }
        }


        public Task<User> GetUserAsync(int userId)
        {
            return db.Table<User>().Where(i => i.UserID == userId).FirstOrDefaultAsync();
        }
        public Task<Inventory> GetInventoryAsync(int inventoryId)
        {
            return db.Table<Inventory>().Where(i => i.UserID == inventoryId).FirstOrDefaultAsync();
        }


        public Task<int> DeleteUserAsync(User user)
        {
            return db.DeleteAsync(user);
        }
        public Task<int> DeleteInventoryAsync(Inventory inventoryser)
        {
            return db.DeleteAsync(inventoryser);
        }
    }
}