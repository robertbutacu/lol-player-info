using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    [DataContract]
    public class MatchDto
    {
        [JsonProperty("gameId")]
        public long gameId { get; set; }

        [JsonProperty("participantIdentities")]
        public List<ParticipantIdentityDto> participantsIdentities { get; set; }

        [JsonProperty("participants")]
        public List<ParticipantIdentityDto> participants { get; set; }
    }
}