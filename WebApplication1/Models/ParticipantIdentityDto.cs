using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WebApplication1.Models
{
    [DataContract]
    public class ParticipantIdentityDto
    {
        [JsonProperty("player")]
        public PlayerDto player { get; set; }

        [JsonProperty("participantId")]
        public int participantId { get; set; }
    }
}