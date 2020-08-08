using Cuckoo.Controls;
using Cuckoo.ViewModels;
using QzSdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cuckoo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewModel;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LoginViewModel();

        }

        private void ProvincePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedItem = (Province)picker.SelectedItem;

            if (selectedItem != null)
            {
                viewModel.SchoolItems.Clear();
                var schools = QzSdk.Qz.GetSchools().Where(x => x.AreaId == selectedItem.Id).ToList();
                foreach (var item in schools)
                {
                    viewModel.SchoolItems.Add(item);
                }
            }
        }

        private async void SchoolPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedItem = (School)picker.SelectedItem;

            if (selectedItem != null)
            {
                viewModel.SchoolLogoImageUrl = await Utils.Functions.GetImageSourceFromUrlAsync(selectedItem.LogoUrl);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            DependencyService.Get<IToast>().ShortAlert("你必须登录...");
            return true;
            // return base.OnBackButtonPressed();
        }

    }
}