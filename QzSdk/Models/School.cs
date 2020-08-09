using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QzSdk.Models
{
    public class School
    {
        private string apiUrl;
        private string logoUrl;

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photo")]
        public string LogoUrl
        {
            get => logoUrl;
            set
            {
                logoUrl = $"{Qz.LogoUrlHost}{value}";
            }
        }

        [JsonProperty("areaId")]
        public string AreaId { get; set; }

        [JsonProperty("jwurl", NullValueHandling = NullValueHandling.Ignore)]
        public string ApiUrl
        {
            get => apiUrl;
            set
            {
                apiUrl = value;
                var m = Regex.Match(value, "https?://(.+)/");
                if (m.Success && m.Groups.Count > 1)
                    ApiHost = m.Groups[1].Value;
            }
        }
        public string ApiHost { get; private set; } = null;
    }
}
