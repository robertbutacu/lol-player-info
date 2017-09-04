using System.Runtime.Serialization;

namespace WebApplication1.Models
{
    [DataContract]
    public class PlayerDto
    {

        public string summonerName { get; set; }

        public long summonerId { get; set; }

        public long accountId { get; set; }
    }
}