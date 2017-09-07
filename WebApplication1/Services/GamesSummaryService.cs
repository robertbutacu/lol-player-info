using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    /*
    Games carried     -> the player's dmg is the highest by a margin of 45% more than the next teammate
    Games fed         -> (kills + assists/0.70) / deaths < 1; 
    Games got carried -> fed and dmg is at least 30% less than the most dmg on the team
    */
    public class GamesSummaryService
    {
        private Boolean HasFed(PlayerScores playerScores)
        {
            return ((playerScores.averageKills + playerScores.averageAssists * 0.70) / playerScores.averageDeaths) < 1;
        }

        private Boolean HasCarried(DamageDealt byPlayer, DamageDealt highestInTeam)
        {
            return byPlayer.averageDmgToChampions > (highestInTeam.averageDmgToChampions * 1.45);
        }

        private Boolean HasGottenCarried(PlayerScores playerScores, DamageDealt byPlayer, DamageDealt highestInTeam)
        {
            return HasFed(playerScores) && (byPlayer.averageDmgToChampions * 1.30 < highestInTeam.averageDmgToChampions);
        }
    }
}