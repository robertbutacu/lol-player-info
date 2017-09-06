using System.Runtime.Serialization;

namespace WebApplication1.Models
{
    [DataContract]
    public class DamageDealt
    {
        [DataMember]
        public double averageDmgToChampions;

        [DataMember]
        public double averageDmgToTurrets;

        public DamageDealt() { }
    }
}