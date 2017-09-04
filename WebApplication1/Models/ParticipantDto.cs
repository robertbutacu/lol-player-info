using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WebApplication1.Models
{
    [DataContract]
    public class ParticipantDto
    {
        [JsonProperty("stats")]
        public ParticipantStatsDto stats { get; set; }

        [JsonProperty("participantId")]
        public int participantId { get; set; }

        [JsonProperty("championId")]
        public int championId { get; set; }
    }
}