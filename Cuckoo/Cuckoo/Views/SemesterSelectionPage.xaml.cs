using Cuckoo.Services;
using Cuckoo.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await Navigation.PopModalAsync();
        }

        private async void Cancel_Clicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PopModalAsync();
        }

    }
}