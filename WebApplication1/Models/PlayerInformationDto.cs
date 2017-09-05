using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    [DataContract]
    public class PlayerInformationDto
    {
        [DataMember]
        public string name;

        [DataMember]
        public Dictionary<string, int> lanesPlayedCount { get; set; }

        [DataMember]
        public PlayerScores playerScores { get; set; }

        [DataMember]
        public GamesSummary gamesSummary { get; set; }

        [DataMember]
        public DamageDealt damageDealt { get; set; }

        [DataMember]
        public DamageDealt damageDealtByEnemies { get; set; }

        [DataMember]
        public DamageDealt damageDealtByTeammates { get; set; }

        public PlayerInformationDto()
        {
        }
    }
}