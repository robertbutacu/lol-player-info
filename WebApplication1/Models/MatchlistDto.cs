using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WebApplication1.Models;

namespace WebApplication1.LolAPIServices
{
    [DataContract]
    public class MatchlistDto
    {
        [JsonProperty("matches")]
        public List<MatchReferenceDto> matches { get; set; }

        [JsonProperty("totalGames")]
        public int totalGames { get; set; }
    }
}