using Cuckoo.Models;
using Cuckoo.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cuckoo.Services
{
    public class EasyCourseDataStore : ICourseDataStore
    {
        public async Task<List<IListItem>> GetCoursesAsync(string semester, int week, int dayOfWeek)
        {
            var courses = await Api.Jw.GetCoursesAsync(week, semester);

            //var init_list = Enumerable.Repeat(new EmptyItem(), 6).ToList<IListItem>();
            var result = new Dictionary<int, List<IListItem>>()
            {
                { 0, Enumerable.Repeat(new EmptyItem(), 6).ToList<IListItem>() },
                { 1, Enumerable.Repeat(new EmptyItem(), 6).ToList<IListItem>() },
                { 2, Enumerable.Repeat(new EmptyItem(), 6).ToList<IListItem>() },
                { 3, Enumerable.Repeat(new EmptyItem(), 6).ToList<IListItem>() },
                { 4, Enumerable.Repeat(new EmptyItem(), 6).ToList<IListItem>() },
                { 5, Enumerable.Repeat(new EmptyItem(), 6).ToList<IListItem>() },
                { 6, Enumerable.Repeat(new EmptyItem(), 6).ToList<IListItem>() }
            };
            //int m = 0;
            for (int i = 0; i < courses.Count; i++)
            {
                var c = courses[i];
                //for(int t = c.Period - m; t > 0;t--)
                //{
                //    result[c.DayOfWeek].Add(new EmptyItem());
                //}
                //m = c.Period + 1;

                result[c.DayOfWeek][c.Period] = new CourseItem()
                {
                    CourseName = c.CourseName,
                    Classroom = c.Classroom,
                    Teacher = c.TeacherName
                };
            }
            int count = result[dayOfWeek].Count;
            result[dayOfWeek].Insert(0, new GroupItem("上午"));
            result[dayOfWeek].Insert(count / 3 + 1, new GroupItem("下午"));
            result[dayOfWeek].Insert(count * 2 / 3 + 2, new GroupItem("晚上"));
            return result[dayOfWeek];
        }

        public async Task<List<IListItem>> GetCoursesFromCacheAsync(string semester, int week, int dayOfWeek)
        {
            var courseData = await Database.CourseDatabase.GetCourseAsync(semester, week, dayOfWeek);
            if (courseData == null || courseData.Count == 0)
                return await GetCoursesAsync(semester, week, dayOfWeek);
            var listItems = new List<IListItem>();
            foreach (var course in courseData)
            {
                listItems.Add(new CourseItem()
                {
                    Classroom = course.Classroom,
                    CourseName = course.CourseName,
                    Teacher = course.Teacher
                });
            }
            listItems.Insert(0, new GroupItem("上午"));
            listItems.Insert(courseData.Count / 3, new GroupItem("下午"));
            listItems.Insert(courseData.Count * 2 / 3, new GroupItem("晚上"));
            return listItems;
        }
    }
}
