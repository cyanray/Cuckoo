using Cuckoo.Services;
using Cuckoo.Views;
using Xamarin.Forms;

namespace Cuckoo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<EasyCourseDataStore>();
            MainPage = new NavigationPage(new MainPage()) { BarTextColor = Color.Black };
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
