using Cuckoo.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuckoo.Services
{
    public class SemesterTime
    {
        private static int week { get; set; } = 0;

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
            int year = DateTime.Now.Year;
            if (DateTime.Now.Month < 8)
            {
                return $"{year - 1}-{year}-2";
            }
            else
            {
                return $"{year}-{year + 1}-2";
            }
        }

        public async static Task<int> GetWeekAsync()
        {
            if (week == 0)
                return await Api.Jw.GetWeekAsync();
            else
                return week;
        }

    }
}
