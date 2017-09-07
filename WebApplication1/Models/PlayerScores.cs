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
            this.averageKills += currentPlayerScores.averageKills;
            this.averageDeaths += currentPlayerScores.averageDeaths;
            this.averageAssists += currentPlayerScores.averageAssists;
        }

        public void NormalizeScores(int totalGames)
        {
            this.averageAssists = Math.Round(this.averageAssists / totalGames, 2);
            this.averageDeaths  = Math.Round(this.averageDeaths  / totalGames, 2);
            this.averageKills   = Math.Round(this.averageKills   / totalGames, 2);
        }
    }
}