using System.Runtime.Serialization;

namespace WebApplication1.Models
{
    [DataContract]
    public class DamageDealt
    {
        [DataMember]
        public int averageDmgToChampions;

        [DataMember]
        public int averageDmgToTurrets;

        public DamageDealt() { }
    }
}