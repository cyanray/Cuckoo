﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
                // TODO: Match ApiHost
                // ApiHost = ...
            }
        }
        public string ApiHost { get; } = null;
    }
}