using Cuckoo.Services;
using System;

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
            int w = FormatDayOfWeek(DateTime.Now.DayOfWeek);
            this.SelectedItem = this.Children[w];
        }

        private int FormatDayOfWeek(DayOfWeek w)
        {
            if (w == DayOfWeek.Sunday) return 6;
            else return (int)w - 1;
        }

        public async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SemesterSelectionPage()));
        }
    }
}