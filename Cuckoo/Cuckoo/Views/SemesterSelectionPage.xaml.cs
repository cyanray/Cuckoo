using Cuckoo.Services;
using Cuckoo.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cuckoo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SemesterSelectionPage : ContentPage
    {

        public SemesterSelectionPage()
        {
            InitializeComponent();
            BindingContext = new SemesterSelectionViewModel();
        }

        private async void Save_Clicked(object sender, EventArgs eventArgs)
        {
            SemesterTime.Semester = (string)semesterPicker.SelectedItem;
            SemesterTime.Week = (int)weekPicker.SelectedItem;
            MessagingCenter.Send(this, "Refresh", string.Empty);
            await Navigation.PopModalAsync();
        }

        private async void Cancel_Clicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PopModalAsync();
        }

    }
}