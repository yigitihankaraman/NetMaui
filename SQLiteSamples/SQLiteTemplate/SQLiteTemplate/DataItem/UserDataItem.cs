using SQLite;
using SQLiteTemplate.Models;


namespace SQLiteTemplate.DataItem
{
    class UserDataItem
    {
        const string DatabaseFilename = "UserSQLite.db3";

        const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        SQLiteAsyncConnection Database; //= new(DatabasePath);

        public async Task<List<User>> GetItemsAsync()
        {
            await InitDatabasse();
            return await Database.Table<User>().ToListAsync();
        }

        public async Task<User> GetById(int userId)
        {
            await InitDatabasse();
            return await Database.Table<User>().Where(i => i.Id == userId).FirstOrDefaultAsync();
        }

        public async Task<int> InsertItemAsync(User item)
        {
            await InitDatabasse();
            return await Database.InsertAsync(item);
        }

        public async Task<int> UpdateItemAsync(User item)
        {
            await InitDatabasse();
            return await Database.UpdateAsync(item);
        }

        async Task InitDatabasse()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(DatabasePath, Flags);
            await Database.CreateTableAsync<User>();
        }
    }
}
