using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    [DataContract]
    public class PlayerInformation
    {
        [DataMember]
        public string name;

        [DataMember]
        public Dictionary<string, int> lanesPlayed;

        [DataMember]
        public double averageCsPerMinute;

        [DataMember]
        public double averageKda;

        [DataMember]
        public int gamesFed;

        [DataMember]
        public int gamesCarried;

        [DataMember]
        public int gamesGotCarried;

        [DataMember]
        public int averageDmgToChampions;

        [DataMember]
        public int averageDmgToTurrets;

        [DataMember]
        public int averageDmgToChampionsEnemies;

        [DataMember]
        public int averageDmgToTurretsEnemies;

        [DataMember]
        public int averageDmgToTurretsTeammates;

        [DataMember]
        public int averageDmgToChampionsTeammates;

        [DataMember]
        public int averageKills;

        [DataMember]
        public int averageDeaths;

        [DataMember]
        public int averageAssists;

    }
}