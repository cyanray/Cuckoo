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
    public class CourseDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.DatabaseFlags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public CourseDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(CourseData).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(CourseData)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<CourseData>> GetCourseDataAsync()
        {
            return Database.Table<CourseData>().ToListAsync();
        }

        public Task<int> SaveCourseDataAsync(CourseData item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        // TODO: more course database methods

    }
}
