using System.Runtime.Serialization;

namespace WebApplication1.Models
{
    [DataContract]
    public class GamesSummary
    {
        [DataMember]
        public int gamesFed;

        [DataMember]
        public int gamesCarried;

        [DataMember]
        public int gamesGotCarried;

        public GamesSummary() { }
    }
}