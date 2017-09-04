using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    [DataContract]
    public class SummonerDto
    {
        [JsonProperty("profileIconId")]
        public long profileIconId { get; }

        [JsonProperty("name")]
        public string name { get; }

        [JsonProperty("summonerLevel")]
        public int summonerLevel { get; }

        [JsonProperty("accountId")]
        public long accountId { get; }

        [JsonProperty("id")]
        public long id{ get; }

        [JsonProperty("revisionDate")]
        public long revisionDate { get; }
    }
}