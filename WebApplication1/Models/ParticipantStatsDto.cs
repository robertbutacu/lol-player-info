using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace WebApplication1.Models
{
    [DataContract]
    public class ParticipantStatsDto
    {
        [JsonProperty("totalDamageDealtToChampions")]
        public long totalDamageDealtToChampions { get; set; }

        [JsonProperty("win")]
        public Boolean win { get; set; }

        [JsonProperty("damageDealtToTurrets")]
        public long damageDealtToTurrets { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("totalScoreRank")]
        public int totalScoreRank { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("neutralMinionsKilled")]
        public int neutralMinionsKilled { get; set; }

        [JsonProperty("assists")]
        public int assists { get; set; }

        [JsonProperty("totalMinionsKilled")]
        public int totalMinionsKilled { get; set; }

        [JsonProperty("goldEarned")]
        public int goldEarned { get; set; }
    }
}