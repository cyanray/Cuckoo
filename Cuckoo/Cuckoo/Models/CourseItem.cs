﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cuckoo.Models
{
    public class CourseItem : IListItem
    {
        public string CourseName { get; set; }
        public string Classroom { get; set; }
        public string Teacher { get; set; }
    }
}
