using Cuckoo.Models;
using Cuckoo.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cuckoo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursesListView : ContentPage
    {
        private readonly CourseItemViewModel viewModel;


        public CoursesListView()
        {
            InitializeComponent();
            BindingContext = viewModel = new CourseItemViewModel();
        }

        public CoursesListView(int index)
        {
            InitializeComponent();
            BindingContext = viewModel = new CourseItemViewModel(index);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CourseDetails());
        }
    }
}