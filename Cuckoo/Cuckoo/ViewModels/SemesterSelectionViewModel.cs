using Cuckoo.Models;
using Cuckoo.Services;
using Cuckoo.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Cuckoo.ViewModels
{
    public class SemesterSelectionViewModel : BaseViewModel
    {
        readonly string[] SemesterName =
        {
            "大一","大一","大二","大二","大三","大三","大四","大四"
        };
        public ObservableCollection<SemesterDisplayItem> Semesters { get; set; }
        public ObservableCollection<int> Weeks { get; set; }
        public SemesterDisplayItem SemesterSelectedItem { get; set; }
        public int WeekSelectedItem { get; set; }

        public SemesterSelectionViewModel()
        {
            Semesters = new ObservableCollection<SemesterDisplayItem>();
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

            var userData = Database.UserDatabase.GetUserData();

            var semesters = SemesterTime.GetSemesterAll(Int32.Parse(userData.Grade));
            for (int i = 0; i < semesters.Count; i++)
            {
                SemesterDisplayItem item = new SemesterDisplayItem();
                item.Semester = semesters[i];
                item.DisplayTitle = $"{SemesterName[i]}: {semesters[i]}";
                Semesters.Add(item);

                if (semesters[i] == SemesterTime.Semester)
                {
                    SemesterSelectedItem = item;
                }
            }

        }


    }
}
