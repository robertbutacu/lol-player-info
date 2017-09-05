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
        public int averageKills;

        [DataMember]
        public int averageDeaths;

        [DataMember]
        public int averageAssists;

        public PlayerScores()
        {
        }
    }
}