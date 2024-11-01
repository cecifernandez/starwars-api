using System.Text.Json.Serialization;

namespace swBackend.Models
{
    public class CharacterModel
    {
        

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("films")]
        public List<string> Films { get; set; }

        [JsonPropertyName("homeworld")]
        public string Planet { get; set; }

        [JsonPropertyName("species")]
        public List<string> Species { get; set; }

        [JsonPropertyName("vehicles")]
        public List<string> Vehicles { get; set; }

        [JsonPropertyName("starships")]
        public List<string> Starships { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
