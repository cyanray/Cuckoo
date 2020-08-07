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

        ImageSource schoolLogoImageUrl = ImageSource.FromFile(Constants.LoginBannerPngFileName);
        public ImageSource SchoolLogoImageUrl
        {
            get { return schoolLogoImageUrl; }
            set { SetProperty(ref schoolLogoImageUrl, value); }
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

            var provinces = await Task.Run(() => { return QzSdk.Qz.GetProvinces(); });
            foreach (var item in provinces)
            {
                ProvinceItems.Add(item);
            }
            IsBusy = false;


        }

        public static ImageSource GetStreamFromUrl(string url)
        {
            byte[] imageData = null;
            MemoryStream ms;

            ms = null;

            try
            {
                using (var wc = new System.Net.WebClient())
                {
                    imageData = wc.DownloadData(url);
                }
                ms = new MemoryStream(imageData);
            }
            catch (Exception ex)
            {
                //forbidden, proxy issues, file not found (404) etc
            }

            return ImageSource.FromStream(() => ms);
        }

    }
}
