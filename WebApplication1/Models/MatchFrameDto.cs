using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    [DataContract]
    public class MatchFrameDto
    {
        [JsonProperty("timestamp")]
        public long timestamp { get; set; }

        [JsonProperty("participantsFrame")]
        public Dictionary<int, MatchParticipantFrameDto> participantFrames { get; set; }

        [JsonProperty("events")]
        public List<MatchEventDto> events { get; set; }

    }
}