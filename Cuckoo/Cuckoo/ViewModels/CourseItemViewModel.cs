using Cuckoo.Models;
using Cuckoo.Services;
using Cuckoo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        private readonly int dayOfWeek = 0;

        public CourseItemViewModel()
        {
            Items = new ObservableCollection<IListItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public CourseItemViewModel(int index)
        {
            dayOfWeek = index;
            Items = new ObservableCollection<IListItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            MessagingCenter.Subscribe<SemesterSelectionPage, string>(this, "Refresh", (sender, arg) =>
            {
                // refresh CollectionView
                IsBusy = true;
            });
            MessagingCenter.Subscribe<ClassSchedulePage, string>(this, "Refresh", (sender, arg) =>
            {
                // refresh CollectionView
                IsBusy = true;
            });
        }

        private async Task ExecuteLoadItemsCommand()
        {

            IsBusy = true;

            try
            {
                IEnumerable<IListItem> items;

                string semester = SemesterTime.GetThisSemester();
                int week = await SemesterTime.GetWeekAsync();
                if (Items.Count == 0)
                {
                    // 第一次获取先从本地文件缓存获取
                    items = await DataStore.GetCoursesFromCacheAsync(semester, week, dayOfWeek);
                }
                else
                {
                    // 手动刷新，则从网络Api获取
                    Items.Clear();
                    items = await DataStore.GetCoursesAsync(semester, week, dayOfWeek);
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
