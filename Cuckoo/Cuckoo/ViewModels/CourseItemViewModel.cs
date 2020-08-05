using Cuckoo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Cuckoo.ViewModels
{
    public class CourseItemViewModel : BaseViewModel
    {
        public ObservableCollection<IListItem> Items { get; set; }

        public CourseItemViewModel()
        {
            Items = new ObservableCollection<IListItem>();
        }

        public CourseItemViewModel(int index)
        {
            // TODO: Get Items by index
            Items = new ObservableCollection<IListItem>()
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

    }
}
