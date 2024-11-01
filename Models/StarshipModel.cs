using System.Text.Json.Serialization;

namespace swBackend.Models
{
    public class StarshipModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("pilots")]
        public List<string> Pilot { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
