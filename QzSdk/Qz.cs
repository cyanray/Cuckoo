using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QzSdk.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QzSdk
{
    public class Qz
    {
        public static readonly string LogoUrlHost = "http://app.qzdatasoft.com:9876";
        private string apiHost;
        static List<Province> Provinces { get; set; } = null;
        static List<School> Schools { get; set; } = null;

        public Qz(string api_host)
        {
            apiHost = api_host;
        }

        public static List<Province> GetProvinces()
        {
            if (Provinces != null) return Provinces;
            var task = FetchProvincesAndSchoolsAsync();
            task.Wait();
            return Provinces;
        }

        public static List<School> GetSchools()
        {
            if (Schools != null) return Schools;
            var task = FetchProvincesAndSchoolsAsync();
            task.Wait();
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
            try
            {
                Provinces = provinceArray.ToObject<List<Province>>();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }


            var schoolArray = json["school"].Value<JArray>();
            Schools = schoolArray.ToObject<List<School>>();
        }
    }
}
