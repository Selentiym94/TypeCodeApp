using System.Text.Json.Serialization;

namespace HTTPClientTest.Models
{
    public class Geo
    {
        [JsonPropertyName("lng")]
        public string Longitude { get; set; }
        [JsonPropertyName("lat")]
        public string Latitude { get; set; }
    }
}
