using Cuckoo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

        }

        async void OnClassScheduleTapped(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ClassSchedulePage()));
        }

    }
}
