using Cuckoo.Controls;
using Cuckoo.Models;
using Cuckoo.Utils;
using Cuckoo.ViewModels;
using QzSdk;
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
        string apiHost;

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
                apiHost = selectedItem.ApiHost;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            DependencyService.Get<IToast>().ShortAlert("你必须登录...");
            return true;
            // return base.OnBackButtonPressed();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (SchoolPicker.SelectedIndex == -1)
            {
                await DisplayAlert("提示", "请先选择学校", "确定");
                return;
            }
            if (apiHost == null)
            {
                await DisplayAlert("提示", "所选的学校暂不支持", "确定");
                return;
            }
            if (string.IsNullOrEmpty(this.SchoolIdEntry.Text) || string.IsNullOrEmpty(this.PasswordEntry.Text))
            {
                await DisplayAlert("提示", "请填写学号和密码", "确定");
                return;
            }
            if (Api.Jw == null)
                Api.Jw = new Qz(apiHost);
            try
            {
                await Api.Jw.Login(this.SchoolIdEntry.Text, this.PasswordEntry.Text);
                var studentInfo = await Api.Jw.GetStudentInfoAsync();
                UserData userData = new UserData()
                {
                    SchoolId = SchoolIdEntry.Text,
                    Password = PasswordEntry.Text,
                    RemoteApiHost = apiHost,
                    SchoolName = ((School)SchoolPicker.SelectedItem).Name,
                    StudentName = studentInfo.StudentName
                };
                await Database.UserDatabase.SaveUserDataAsync(userData);
                DependencyService.Get<IToast>().LongAlert("登录成功");
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("出现错误", ex.Message, "确定");
            }
        }
    }
}