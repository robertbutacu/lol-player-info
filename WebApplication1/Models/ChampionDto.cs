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
        public int id { get; set; }

        [JsonProperty("key")]
        public String key { get; set; }

        [JsonProperty("name")]
        public String name { get; set; }

        [JsonProperty("title")]
        public String title { get; set; }
    }
}