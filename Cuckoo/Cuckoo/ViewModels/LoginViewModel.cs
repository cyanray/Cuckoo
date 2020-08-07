using Cuckoo.Utils;
using QzSdk.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cuckoo.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ObservableCollection<Province> ProvinceItems { get; set; }
        public ObservableCollection<School> SchoolItems { get; set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        ImageSource schoolLogoImage = ImageSource.FromFile(Constants.LoginBannerPngFileName);
        public ImageSource SchoolLogoImageUrl
        {
            get { return schoolLogoImage; }
            set { SetProperty(ref schoolLogoImage, value); }
        }

        public LoginViewModel()
        {
            ProvinceItems = new ObservableCollection<Province>();
            SchoolItems = new ObservableCollection<School>();
            _ = LoadProvinceItemsAsync();
        }

        private async Task LoadProvinceItemsAsync()
        {
            IsBusy = true;
            // 模拟网络不好的情况
            // await Task.Delay(3000);
            var provinces = await Task.Run(() => { return QzSdk.Qz.GetProvinces(); });
            foreach (var item in provinces)
            {
                ProvinceItems.Add(item);
            }
            IsBusy = false;


        }

    }
}
