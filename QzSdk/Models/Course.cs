using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QzSdk.Models
{
    public class Course
    {
        private string rawTime;
        /// <summary>
        /// 课程名称
        /// </summary>
        [JsonProperty("kcmc")]
        public string CourseName { get; set; }

        /// <summary>
        /// 教师名称
        /// </summary>
        [JsonProperty("jsxm")]
        public string TeacherName { get; set; }

        /// <summary>
        /// 上课教室
        /// </summary>
        [JsonProperty("jsmc")]
        public string Classroom { get; set; }

        /// <summary>
        /// 上课时间
        /// </summary>
        [JsonProperty("kssj")]
        public string BeginTime { get; set; }

        /// <summary>
        /// 下课时间
        /// </summary>
        [JsonProperty("jssj")]
        public string OverTime { get; set; }

        /// <summary>
        /// 数据库记录的原始上课时间
        /// </summary>
        [JsonProperty("kcsj")]
        public string RawTime
        {
            get => rawTime;
            set
            {
                rawTime = value;
                DayOfWeek = Int32.Parse(value.Substring(0, 1)) - 1;
                int t = Int32.Parse(value.Substring(1, 2));
                Period = (t - 1) / 2;
            }
        }

        /// <summary>
        /// 星期几的课
        /// </summary>
        public int DayOfWeek { get; set; }

        /// <summary>
        /// 第几节课
        /// </summary>
        public int Period { get; set; }
    }
}
