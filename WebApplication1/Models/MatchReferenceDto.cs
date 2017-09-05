using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    [DataContract]
    public class MatchReferenceDto
    {
        [JsonProperty("lane")]
        public string lane { get; set; }

        [JsonProperty("gameId")]
        public long gameId { get; set; }

        [JsonProperty("role")]
        public string role { get; set; }
    }
}