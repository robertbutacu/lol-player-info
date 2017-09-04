using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WebApplication1.Models
{
    [DataContract]
    public class PlayerDto
    {
        [JsonProperty("summonerName")]
        public string summonerName { get; set; }

        [JsonProperty("summonerId")]
        public long summonerId { get; set; }

        [JsonProperty("accountId")]
        public long accountId { get; set; }
    }
}