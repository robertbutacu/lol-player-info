using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    [DataContract]
    public class ChampionDto
    {
        [JsonProperty("id")]
        public int id { get; }

        [JsonProperty("key")]
        public String key { get; }

        [JsonProperty("name")]
        public String name { get; }

        [JsonProperty("title")]
        public String title { get; }
    }
}