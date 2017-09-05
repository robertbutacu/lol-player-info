using System.Runtime.Serialization;

namespace WebApplication1.Models
{
    [DataContract]
    public class PlayerScores
    {
        [DataMember]
        public double averageCsPerMinute;

        [DataMember]
        public double averageKda;

        [DataMember]
        public double averageKills;

        [DataMember]
        public double averageDeaths;

        [DataMember]
        public double averageAssists;

        public PlayerScores()
        {
        }
    }
}