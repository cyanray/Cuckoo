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
        private string ApiHost;
        private RestClient ApiClient;
        static List<Province> Provinces { get; set; } = null;
        static List<School> Schools { get; set; } = null;

        public string Token { get; set; } = null;
        public string SchoolId { get; set; } = null;

        public Qz(string api_host)
        {
            ApiHost = api_host;
            ApiClient = new RestClient(api_host);
        }

        public static List<Province> GetProvinces()
        {
            if (Provinces != null) return Provinces;
            var task = FetchProvincesAndSchoolsAsync();
            task.Wait();
            return Provinces;
        }

        public async Task<int> GetWeekAsync()
        {
            if (Token == null) throw new Exception("未登录教务系统");
            var request = new RestRequest($"app.do?method=getCurrentTime&currDate={DateTime.Now:yyyy-MM-dd}");
            request.AddHeader("token", Token);
            var response = await ApiClient.ExecuteGetAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("非200状态响应");
            var json = JObject.Parse(response.Content);
            return json["zc"].Value<int>();
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

        public async Task Login(string schoolId, string password)
        {
            var request = new RestRequest($"app.do?method=authUser&xh={schoolId}&pwd={password}");
            var response = await ApiClient.ExecuteGetAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("非200状态响应");
            var json = JObject.Parse(response.Content);
            string token = json["token"].Value<string>();
            string err_msg = json["msg"].Value<string>();
            if (token == "-1") throw new Exception($"登录错误,{err_msg}");
            this.Token = token;
            this.SchoolId = schoolId;
        }

        public async Task<StudentInfo> GetStudentInfoAsync(string schoolId = null)
        {
            if (Token == null) throw new Exception("未登录教务系统");
            if (schoolId == null) schoolId = this.SchoolId;
            var request = new RestRequest($"app.do?method=getUserInfo&xh={schoolId}");
            request.AddHeader("token", Token);
            var response = await ApiClient.ExecuteGetAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("非200状态响应");
            return JsonConvert.DeserializeObject<StudentInfo>(response.Content);
        }

        public async Task<List<Course>> GetCoursesAsync(int week, string semester = "", string schoolId = null)
        {
            if (Token == null) throw new Exception("未登录教务系统");
            if (schoolId == null) schoolId = this.SchoolId;
            var request = new RestRequest($"app.do?method=getKbcxAzc&xh={schoolId}&xnxqid={semester}&zc={week}");
            request.AddHeader("token", Token);
            var response = await ApiClient.ExecuteGetAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("非200状态响应");
            var json = JArray.Parse(response.Content);
            return json.ToObject<List<Course>>();
        }

    }
}
