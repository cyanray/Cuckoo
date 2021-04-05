using Cuckoo.Services;
using Cuckoo.Utils;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cuckoo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseSchedulePage : TabbedPage
    {
        public CourseSchedulePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var week = await SemesterTime.GetWeekAsync();
            DisplayWeekToolItem(week);
            int w = FormatDayOfWeek(DateTime.Now.DayOfWeek);
            this.SelectedItem = this.Children[w];
        }

        private int FormatDayOfWeek(DayOfWeek w)
        {
            if (w == DayOfWeek.Sunday) return 6;
            else return (int)w - 1;
        }

        private void DisplayWeekToolItem(int week)
        {
            WeekToolbarItem.Text = $"第 {week} 周";
        }

        public async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SemesterSelectionPage()));
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            int t = SemesterTime.Week - 1;
            if (t >= 1)
            {
                SemesterTime.Week -= 1;
                DisplayWeekToolItem(SemesterTime.Week);
                MessagingCenter.Send(this, "Refresh", string.Empty);
            }
        }

        private void ToolbarItem_Clicked_2(object sender, EventArgs e)
        {
            int t = SemesterTime.Week + 1;
            if (t <= Constants.MaxWeekNumber)
            {
                SemesterTime.Week += 1;
                DisplayWeekToolItem(SemesterTime.Week);
                MessagingCenter.Send(this, "Refresh", string.Empty);
            }
        }
    }
}