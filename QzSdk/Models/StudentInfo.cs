using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QzSdk.Models
{
    public class StudentInfo
    {
        [JsonProperty("xh")]
        public string SchoolId { get; set; }
        
        [JsonProperty("xm")]
        public string StudentName { get; set; }
        
        [JsonProperty("yxmc")]
        public string CollegeName { get; set; }

        [JsonProperty("zymc")]
        public string Major { get; set; }

        [JsonProperty("bj")]
        public string ClassName { get; set; }

        [JsonProperty("nj")]
        public string Grade { get; set; }
    }
}
