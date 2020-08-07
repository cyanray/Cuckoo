using Cuckoo.Services;
using Cuckoo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cuckoo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // TODO: Replace with QzApi or my api
            DependencyService.Register<MockUserDataStore>();
            MainPage = new NavigationPage(new LoginPage()) { BarBackgroundColor = Color.Blue, BarTextColor = Color.White };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
