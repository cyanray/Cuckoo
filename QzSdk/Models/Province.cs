using Newtonsoft.Json;

namespace QzSdk.Models
{
    public class Province
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
