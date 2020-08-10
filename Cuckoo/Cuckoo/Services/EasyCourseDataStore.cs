using Cuckoo.Models;
using Cuckoo.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuckoo.Services
{
    public class EasyCourseDataStore : ICourseDataStore
    {
        public Task<List<IListItem>> GetCoursesAsync(string semester, int week, int dayOfWeek)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IListItem>> GetCoursesFromCacheAsync(string semester, int week, int dayOfWeek)
        {
            var courseData = await Database.CourseDatabase.GetCourseAsync(semester, week, dayOfWeek);
            if (courseData == null || courseData.Count == 0) return null;
            var listItems = new List<IListItem>();
            foreach(var course in courseData)
            {
                listItems.Add(course.Course);
            }
            listItems.Insert(0, new GroupItem("上午"));
            listItems.Insert(courseData.Count / 3, new GroupItem("下午"));
            listItems.Insert(courseData.Count * 2 / 3, new GroupItem("晚上"));
            return await Task.FromResult(listItems);
        }
    }
}
