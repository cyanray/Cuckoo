using Cuckoo.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Cuckoo.ViewModels
{
    public class SemesterSelectionViewModel : BaseViewModel
    {
        public ObservableCollection<string> Semesters { get; set; }
        public ObservableCollection<int> Weeks { get; set; }
        public string SemesterSelectedItem { get; set; }
        public int WeekSelectedItem { get; set; }

        public SemesterSelectionViewModel()
        {
            Semesters = new ObservableCollection<string>();
            Weeks = new ObservableCollection<int>();

            // 一般是 20 周，如果 remote api 给的周数过多，则进行适配
            int max_week = Math.Max(20, SemesterTime.Week);
            var weeks = Enumerable.Range(1, max_week).ToList();
            foreach (var w in weeks)
            {
                Weeks.Add(w);
                if (w == SemesterTime.Week)
                {
                    WeekSelectedItem = w;
                }
            }


            var semesters = SemesterTime.GetSemesterAll(2018);
            foreach (var s in semesters)
            {
                Semesters.Add(s);
                if (s == SemesterTime.Semester)
                {
                    SemesterSelectedItem = s;
                }
            }

        }


    }
}
