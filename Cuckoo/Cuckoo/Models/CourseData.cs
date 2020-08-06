using System;
using System.Collections.Generic;
using System.Text;

namespace Cuckoo.Models
{
    /// <summary>
    /// 课程信息实体，存于数据库
    /// </summary>
    public class CourseData
    {
        public int Id { get; set; }
        public string Semester { get; set; }
        public string Week { get; set; }
        public string DayOfWeek { get; set; }
        public int Period { get; set; }
        public CourseItem Course { get; set; }
    }
}
