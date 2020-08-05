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
            Title = "课课课表";
            Items = new ObservableCollection<IListItem>();
        }

    }
}
