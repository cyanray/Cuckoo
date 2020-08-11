using Cuckoo.Services;
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
    public partial class ClassSchedulePage : TabbedPage
    {
        public ClassSchedulePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var week = await SemesterTime.GetWeekAsync();
            WeekToolbarItem.Text = $"第{week}周";
        }

        public async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SemesterSelectionPage()));
        }
    }
}