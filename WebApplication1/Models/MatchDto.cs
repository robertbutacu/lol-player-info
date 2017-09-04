using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    [DataContract]
    public class MatchDto
    {
        [JsonProperty("events")]
        public List<MatchFrameDto> events;

        [JsonProperty("frameInterval")]
        public long frameInterval { get; set; }
    }
}