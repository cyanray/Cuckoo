using Cuckoo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuckoo.Services
{
    public class MockCourseDataStore : ICourseDataStore
    {
        public async Task<IEnumerable<IListItem>> GetItemsAsync(bool forceRefresh = false)
        {
            var items = new List<IListItem>()
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
            return await Task.FromResult(items);
        }
    }
}
