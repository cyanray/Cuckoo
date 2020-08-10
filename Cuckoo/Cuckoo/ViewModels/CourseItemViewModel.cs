using Cuckoo.Models;
using Cuckoo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cuckoo.ViewModels
{
    public class CourseItemViewModel : BaseViewModel
    {
        public ICourseDataStore DataStore => DependencyService.Get<ICourseDataStore>();

        public ObservableCollection<IListItem> Items { get; set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public Command LoadItemsCommand { get; set; }

        private int DayOfWeek = 0;

        public CourseItemViewModel()
        {
            Items = new ObservableCollection<IListItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public CourseItemViewModel(int index)
        {
            DayOfWeek = index;
            Items = new ObservableCollection<IListItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                IEnumerable<IListItem> items;
                
                if(Items.Count == 0)
                {
                    // 第一次获取先从本地文件缓存获取
                    items = await DataStore.GetCoursesFromCacheAsync("2019-2020-2", 12, DayOfWeek);
                }
                else
                {
                    // 手动刷新，则从网络Api获取
                    Items.Clear();
                    items = await DataStore.GetCoursesAsync("2019-2020-2", 12, DayOfWeek);
                }

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
