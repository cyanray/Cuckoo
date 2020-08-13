using Cuckoo.Controls;
using Cuckoo.Utils;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Cuckoo.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            XamEffects.Commands.SetTap(CourseFrame, new Command(() =>
            {
                OnClassScheduleTapped(null, null);
            }));
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var userData = await Database.UserDatabase.GetUserDataAsync();
            if (userData == null)
            {
                var stack = Navigation.ModalStack;
                if (stack.Count > 0 && ((NavigationPage)stack[stack.Count - 1]).RootPage is LoginPage) return;
                await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
            }
            else
            {
                if (Api.Jw == null)
                {
                    Api.Jw = new QzSdk.Qz(userData.RemoteApiHost);
                    try
                    {
                        await Api.Jw.Login(userData.SchoolId, userData.Password);
                    }
                    catch (Exception ex)
                    {
                        DependencyService.Get<IToast>().LongAlert(ex.Message);
                    }
                }
                this.Welcome.Text = $"{Functions.GreetText()}, {userData.StudentName}";
            }

        }

        async void OnClassScheduleTapped(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ClassSchedulePage()));
        }

        private async void Logout_ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Database.UserDatabase.DeleteUserDataAsync();
            await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
        }
    }
}
