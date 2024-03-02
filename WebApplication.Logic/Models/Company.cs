using System.Text.Json.Serialization;

namespace HTTPClientTest.Models
{
    public  class Company
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("catchphrase")]
        public string CatchPhrase { get; set; }
       
        [JsonPropertyName("bs")]
        public string Bs {  get; set; }
    }
}
