using Cuckoo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Cuckoo.ViewModels
{
    public class SemesterSelectionViewModel: BaseViewModel
    {
        public ObservableCollection<string> Semesters { get; set; }
        public ObservableCollection<int> Weeks { get; set; }

        public SemesterSelectionViewModel()
        {
            Semesters = new ObservableCollection<string>();
            Weeks = new ObservableCollection<int>();

            var weeks = Enumerable.Range(1, 20).ToList();
            foreach (var w in weeks)
            {
                Weeks.Add(w);
            }


            var semesters = SemesterTime.GetSemesterAll(2018);
            foreach(var s in semesters)
            {
                Semesters.Add(s);
            }

        }


    }
}
