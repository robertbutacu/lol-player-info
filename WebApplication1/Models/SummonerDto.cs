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
        public long profileIconId { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("accountId")]
        public long accountId { get; set; }

        [JsonProperty("id")]
        public long id{ get; set; }

        [JsonProperty("revisionDate")]
        public long revisionDate { get; set; }
    }
}