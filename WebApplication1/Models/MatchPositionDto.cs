using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WebApplication1.Models
{
    [DataContract]
    public class MatchPositionDto
    {
        [JsonProperty("x")]
        public int x { get; set; }

        [JsonProperty("y")]
        public int y { get; set; }
    }
}