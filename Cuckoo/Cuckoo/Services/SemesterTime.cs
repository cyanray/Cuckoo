using Cuckoo.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cuckoo.Services
{
    public class SemesterTime
    {
        public static string Semester { get; set; }
        public static int Week { get; set; } = 0;

        public static List<string> GetSemesterAll(int yearOfGrade)
        {
            List<string> result = new List<string>();
            int tYear = yearOfGrade;
            for (int i = 0; i < 4; i++)
            {
                result.Add($"{tYear}-{tYear + 1}-1");
                result.Add($"{tYear}-{tYear + 1}-2");
                tYear++;
            }
            return result;
        }

        public static string GetThisSemester()
        {
            if (!string.IsNullOrEmpty(Semester))
                return Semester;
            int year = DateTime.Now.Year;
            if (DateTime.Now.Month < 8)
            {
                Semester = $"{year - 1}-{year}-2";
            }
            else
            {
                Semester = $"{year}-{year + 1}-1";
            }
            return Semester;
        }

        public async static Task<int> GetWeekAsync()
        {
            if (Week == 0)
                Week = await Api.Jw.GetWeekAsync();
            return Week;
        }

    }
}
