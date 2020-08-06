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

        private int IndexOfWeek = 0;

        public CourseItemViewModel()
        {
            Items = new ObservableCollection<IListItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public CourseItemViewModel(int index)
        {
            IndexOfWeek = index;
            Items = new ObservableCollection<IListItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
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
