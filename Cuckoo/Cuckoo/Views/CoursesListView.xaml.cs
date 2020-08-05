using Cuckoo.Models;
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
    public partial class CoursesListView : ContentPage
    {
        private CourseItemViewModel viewModel;

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
    }
}