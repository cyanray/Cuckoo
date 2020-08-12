using SQLite;

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
        public string CourseName { get; set; }
        public string Classroom { get; set; }
        public string Teacher { get; set; }
    }
}
