using System;
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

        public void Add(double dmgDealtToChampions, double dmgDealtToTurrets)
        {
            this.averageDmgToChampions += dmgDealtToChampions;
            this.averageDmgToTurrets   += dmgDealtToTurrets;
        }

        public void Normalize(int totalGames)
        {
            this.averageDmgToChampions = Math.Round(this.averageDmgToChampions / totalGames, 2);
            this.averageDmgToTurrets   = Math.Round(this.averageDmgToTurrets / totalGames, 2);
        }

        public void Add(DamageDealt other)
        {
            this.averageDmgToChampions += other.averageDmgToChampions;
            this.averageDmgToTurrets   += other.averageDmgToTurrets;
        }

        public void ReplaceDamage(DamageDealt other)
        {
            this.averageDmgToChampions = other.averageDmgToChampions;
            this.averageDmgToTurrets   = other.averageDmgToTurrets;
        }

        public void ReplaceDamage(double dmgToChampions, double dmgToTurrets)
        {
            this.averageDmgToChampions = dmgToChampions;
            this.averageDmgToTurrets   = dmgToTurrets;
        }
    }
}