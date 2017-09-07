using System;
using System.Runtime.Serialization;

namespace WebApplication1.Models
{
    [DataContract]
    public class PlayerScores
    {
        [DataMember]
        public double averageCsPerMinute { get; set; } = 0;

        [DataMember]
        public double averageCreeps { get; set; } = 0;

        [DataMember]
        public double averageKda { get; set; } = 0;

        [DataMember]
        public double averageKills { get; set; } = 0;

        [DataMember]
        public double averageDeaths { get; set; } = 0;

        [DataMember]
        public double averageAssists { get; set; } = 0;

        public PlayerScores()
        {
        }

        public void AddScores(PlayerScores currentPlayerScores)
        {
            this.averageKills   += currentPlayerScores.averageKills;
            this.averageDeaths  += currentPlayerScores.averageDeaths;
            this.averageAssists += currentPlayerScores.averageAssists;
        }

        public void AddScores(double averageKills, double averageDeaths, double averageAssists)
        {
            this.averageKills   += averageKills;
            this.averageDeaths  += averageDeaths;
            this.averageAssists += averageAssists;
        }

        public void NormalizeScores(int totalGames)
        {
            this.averageAssists = Math.Round(this.averageAssists / totalGames, 2);
            this.averageDeaths  = Math.Round(this.averageDeaths  / totalGames, 2);
            this.averageKills   = Math.Round(this.averageKills   / totalGames, 2);
        }

        public void ReplaceScores(PlayerScores playerScores)
        {
            this.averageKills = playerScores.averageKills;
            this.averageDeaths = playerScores.averageDeaths;
            this.averageAssists = playerScores.averageAssists;

            this.averageKda = playerScores.averageKda;

            this.averageCreeps = playerScores.averageCreeps;

            this.averageCsPerMinute = playerScores.averageCsPerMinute;
        }
    }
}