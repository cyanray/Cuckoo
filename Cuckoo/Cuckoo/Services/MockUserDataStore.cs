using Cuckoo.Models;
using Cuckoo.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuckoo.Services
{
    public class MockUserDataStore : IUserDataStore
    {
        private List<IListItem> Items;

        public MockUserDataStore()
        {
            Items = new List<IListItem>()
                {
                    new GroupItem() { GroupName = "上午" },
                    new CourseItem(){ CourseName = "船舶静力学",Classroom="A01-123" },
                    new CourseItem(){ CourseName = "船舶材料力学",Classroom="A01-234" },
                    new GroupItem() { GroupName = "下午" },
                    new EmptyItem(),
                    new CourseItem(){ CourseName = "毛泽东思想与中国特色社会主义概论",Classroom="A01-108" },
                    new GroupItem() { GroupName = "晚上" },
                    new EmptyItem(),
                    new EmptyItem()
                };
        }

        public async Task<IEnumerable<IListItem>> GetCoursesAsync(string semester, int week, int dayOfWeek)
        {
            // 模拟网络延迟
            await Task.Delay(2000);
            return await Task.FromResult(Items);
        }

        public async Task<IEnumerable<IListItem>> GetCoursesFromCacheAsync(string semester, int week, int dayOfWeek)
        {
            return await Task.FromResult(Items);
        }

        public async Task<string> GetSchoolIdAsync()
        {
            var userData = await Database.UserDatabase.GetUserDataAsync();
            if (userData != null)
            {
                return userData.SchoolId;
            }
            UserData tmp = new UserData() { SchoolId = "631805010000" };
            _ = Database.UserDatabase.SaveUserDataAsync(tmp);
            return "631805010409";
        }
    }
}
