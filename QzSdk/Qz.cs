using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QzSdk.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QzSdk
{
    public class Qz
    {
        static List<Province> Provinces { get; set; } = null;
        static List<School> Schools { get; set; } = null;

        public static async Task<List<Province>> GetProvincesAsync()
        {
            if(Provinces == null)
            {
                await FetchProvincesAndSchoolsAsync();
            }
            return Provinces;
        }

        public static async Task<List<School>> GetSchoolsAsync()
        {
            if (Schools == null)
            {
                await FetchProvincesAndSchoolsAsync();
            }
            return Schools;
        }

        private static async Task FetchProvincesAndSchoolsAsync()
        {
            // http://app.qzdatasoft.com:9876/qzkjapp/phone/provinceData
            RestClient restClient = new RestClient("http://app.qzdatasoft.com:9876");
            var request = new RestRequest("qzkjapp/phone/provinceData");
            var response = await restClient.ExecuteGetAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("非200状态响应");

            var json = JObject.Parse(response.Content);
            var provinceArray = json["prov"].Value<JArray>();
            Provinces = provinceArray.ToObject<List<Province>>();

            var schoolArray = json["school"].Value<JArray>();
            Schools = schoolArray.ToObject<List<School>>();
        }
    }
}
