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

        public PlayerInformation(
            string name, Dictionary<string, int> lanesPlayed, double averageCsPerMinute, 
            double averageKda, int gamesFed, int gamesCarried, int gamesGotCarried, int averageDmgToChampions, 
            int averageDmgToTurrets, int averageDmgToChampionsEnemies, int averageDmgToTurretsEnemies, int averageDmgToTurretsTeammates, 
            int averageDmgToChampionsTeammates, int averageKills, int averageDeaths, int averageAssists
            )
        {
            this.name = name;
            this.lanesPlayed = lanesPlayed;
            this.averageCsPerMinute = averageCsPerMinute;
            this.averageKda = averageKda;
            this.gamesFed = gamesFed;
            this.gamesCarried = gamesCarried;
            this.gamesGotCarried = gamesGotCarried;
            this.averageDmgToChampions = averageDmgToChampions;
            this.averageDmgToTurrets = averageDmgToTurrets;
            this.averageDmgToChampionsEnemies = averageDmgToChampionsEnemies;
            this.averageDmgToTurretsEnemies = averageDmgToTurretsEnemies;
            this.averageDmgToTurretsTeammates = averageDmgToTurretsTeammates;
            this.averageDmgToChampionsTeammates = averageDmgToChampionsTeammates;
            this.averageKills = averageKills;
            this.averageDeaths = averageDeaths;
            this.averageAssists = averageAssists;
        }
    }
}