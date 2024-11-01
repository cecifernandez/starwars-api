using System.Text.Json.Serialization;

namespace swBackend.Models
{
    public class SpeciesModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("classification")]
        public List<string> Classification { get; set; }

        [JsonPropertyName("people")]
        public List<string> People { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
