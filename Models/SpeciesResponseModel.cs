using swBackend.Interfaces;

namespace swBackend.Models
{
    public class SpeciesResponseModel : IInfo
    {
        public string Url { get; set; }
        public string Name { get; set; }
    }
}
