using Cuckoo.Models;
using Cuckoo.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuckoo.Services
{
    public class UserDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.DatabaseFlags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public UserDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(UserData).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(UserData)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<UserData> GetUserDataAsync()
        {
            return Database.Table<UserData>().FirstOrDefaultAsync();
        }

        public async Task<int> DeleteUserDataAsync()
        {
            var userData = await GetUserDataAsync();
            return await Database.Table<UserData>().DeleteAsync(item => item.Id == userData.Id);
        }

        public Task<int> SaveUserDataAsync(UserData item)
        {
            return Database.InsertOrReplaceAsync(item);
        }

    }
    public static class TaskExtensions
    {
        // NOTE: Async void is intentional here. This provides a way
        // to call an async method from the constructor while
        // communicating intent to fire and forget, and allow
        // handling of exceptions
        public static async void SafeFireAndForget(this Task task,
            bool returnToCallingContext,
            Action<Exception> onException = null)
        {
            try
            {
                await task.ConfigureAwait(returnToCallingContext);
            }

            // if the provided action is not null, catch and
            // pass the thrown exception
            catch (Exception ex) when (onException != null)
            {
                onException(ex);
            }
        }
    }
}
