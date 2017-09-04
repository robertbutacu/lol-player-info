using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    [DataContract]
    public class MatchEventDto
    {
        [JsonProperty("eventType")]
        public string eventType { get; set; }

        [JsonProperty("towerType")]
        public string towerType { get; set; }

        [JsonProperty("teamId")]
        public int teamId { get; set; }

        [JsonProperty("ascendedType")]
        public string ascendedType { get; set; }

        [JsonProperty("killerId")]
        public int killerId { get; set; }

        [JsonProperty("levelUpType")]
        public string levelUpType { get; set; }

        [JsonProperty("pointCaptured")]
        public string pointCaptured { get; set; }

        [JsonProperty("assitingParticipantIds")]
        public List<int> assistingParticipantIds { get; set; }

        [JsonProperty("wardType")]
        public string wardType { get; set; }

        [JsonProperty("monsterType")]
        public string monsterType { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("skillslot")]
        public int skillSlot { get; set; }

        [JsonProperty("victimId")]
        public int victimId { get; set; }

        [JsonProperty("timestamp")]
        public long timestamp { get; set; }

        [JsonProperty("afterId")]
        public int afterId { get; set; }

        [JsonProperty("monsterSubType")]
        public string monsterSubType { get; set; }

        [JsonProperty("laneType")]
        public string laneType { get; set; }

        [JsonProperty("itemId")]
        public int itemId { get; set; }

        [JsonProperty("participantId")]
        public int participantId { get; set; }

        [JsonProperty("buildingType")]
        public string buildingType { get; set; }

        [JsonProperty("creatorId")]
        public int creatorId { get; set; }

        [JsonProperty("position")]
        public MatchPositionDto position { get; set; }

        [JsonProperty("beforeId")]
        public int beforeId { get; set; }


    }
}