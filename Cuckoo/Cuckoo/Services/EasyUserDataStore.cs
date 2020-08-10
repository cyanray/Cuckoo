using Cuckoo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuckoo.Services
{
    public class EasyUserDataStore : IUserDataStore
    {
        public Task<IEnumerable<IListItem>> GetCoursesAsync(string semester, int week, int dayOfWeek)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IListItem>> GetCoursesFromCacheAsync(string semester, int week, int dayOfWeek)
        {
            throw new NotImplementedException();
        }
    }
}
