using System;

namespace Cuckoo.Utils
{
    public partial class Functions
    {
        public static string GreetText()
        {
            var hour = DateTime.Now.Hour;
            if (hour >= 0 && hour < 6) return "注意休息";
            if (hour >= 6 && hour < 12) return "上午好";
            if (hour >= 12 && hour < 13) return "中午好";
            if (hour >= 13 && hour < 17) return "下午好";
            if (hour >= 17 && hour <= 23) return "晚上好";
            return "你好";
        }

    }
}
