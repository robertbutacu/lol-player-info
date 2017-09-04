using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebApplication1.Models
{
    [DataContract]
    public class ParticipantTimelineDto
    {
        [JsonProperty("participantId")]
        public int participantId { get; set; }

        [JsonProperty("creepsPerMinDeltas")]
        public Dictionary<string, double> creepsPerMinDeltas { get; set; }

        [JsonProperty("role")]
        public string role { get; set; }

        [JsonProperty("lane")]
        public string lane { get; set; }

    }
}