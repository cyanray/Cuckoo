using Cuckoo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuckoo.Services
{
    public interface IUserDataStore
    {
        /// <summary>
        /// 获取学号
        /// </summary>
        /// <returns>学号</returns>
        Task<string> GetSchoolIdAsync();
        /// <summary>
        /// 获取某日的课表
        /// </summary>
        /// <param name="semester">学期，格式如：2019-2020-1</param>
        /// <param name="week">周次，即第几周</param>
        /// <param name="dayOfWeek">该周的第几天</param>
        /// <returns></returns>
        Task<IEnumerable<IListItem>> GetCoursesAsync(string semester, int week, int dayOfWeek);

        /// <summary>
        /// 获取某日的课表(从文件缓存)
        /// </summary>
        /// <param name="semester">学期，格式如：2019-2020-1</param>
        /// <param name="week">周次，即第几周</param>
        /// <param name="dayOfWeek">该周的第几天</param>
        /// <returns></returns>
        Task<IEnumerable<IListItem>> GetCoursesFromCacheAsync(string semester, int week, int dayOfWeek);
    }
}
