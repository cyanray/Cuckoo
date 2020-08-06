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
    public partial class SemesterSelectionPage : ContentPage
    {
        public SemesterSelectionPage()
        {
            InitializeComponent();
        }

        private async void Save_Clicked(object sender, EventArgs eventArgs)
        {
            // TODO: Save Change
            await Navigation.PopModalAsync();
        }

        private async void Cancel_Clicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PopModalAsync();
        }

    }
}