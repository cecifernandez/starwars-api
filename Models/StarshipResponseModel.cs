using swBackend.Interfaces;

namespace swBackend.Models
{
    public class StarshipResponseModel : IInfo
    {
        public string Url { get; set; }
        public string Name { get; set; }
    }
}
