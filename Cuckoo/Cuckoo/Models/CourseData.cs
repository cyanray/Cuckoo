using SQLite;
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
        [PrimaryKey]
        [NotNull]
        [AutoIncrement]
        public int Id { get; set; }
        public string Semester { get; set; }
        public int Week { get; set; }
        public int DayOfWeek { get; set; }
        public int Period { get; set; }
        public CourseItem Course { get; set; }
    }
}
