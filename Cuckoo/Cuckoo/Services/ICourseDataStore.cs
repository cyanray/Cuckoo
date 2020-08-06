using Cuckoo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuckoo.Services
{
    public interface ICourseDataStore
    {
        Task<IEnumerable<IListItem>> GetItemsAsync(bool forceRefresh = false);
    }
}
