using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.LolAPIServices;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PlayerInformationService
    {
            /*
            name - checked
            lanesPlayed 
            averageCsPerMinute
            averageKda
            gamesFed
            gamesCarried
            gamesGotCarried
            averageDmgToChampions
            averageDmgToTurrets
            averageDmgToChampionsEnemies
            averageDmgToTurretsEnemies
            averageDmgToTurretsTeammates
            averageDmgToChampionsTeammates
            averageKills
            averageDeaths
            averageAssists
            */
        public PlayerInformationDto Get(string summonerName, string region) 
        {
            SummonerDto summoner = new Summoner().GetByName(summonerName, region);
            MatchlistDto matchesHistory = new Matches().Get(summoner.accountId, region);

            
            
        }
        /*
            Games carried     -> the player's dmg is the highest.
            Games fed         -> (kills + assists/0.70) / deaths < 1; 
            Games got carried -> 
         */

        private List<MatchDto> GetDetailedGames(List<MatchReferenceDto> matchHistory)
        {
            return null;
        }

        private double ComputeAverageKda(List<MatchDto> matchHistory, long accountId)
        {
            return 0;
        }

        private Dictionary<string, int> ComputeLanesPlayedCount(List<MatchReferenceDto> matchHistory, long accountId)
        {
            return null;
        }

        private double ComputeAverageKills(List<MatchDto> matchHistory, long accountId)
        {
            return 0;
        }

        private double ComputeAverageDeaths(List<MatchDto> matchHistory, long accountId)
        {
            return 0;
        }

        private double ComputeAverageAssists(List<MatchDto> matchHistory, long accountId)
        {
            return 0;
        }

        private double ComputeAverageCsPerMin(List<MatchDto> matchHistory, long accountId)
        {
            return 0;
        }

        private int ComputeGamesFed(List<MatchDto> matchHistory, long accountId)
        {
            return 0;
        }

        private int ComputeGamesCarried(List<MatchDto> matchHistory, long accountId)
        {
            return 0;
        }

        private int ComputeGamesGotCarried(List<MatchDto> matchHistory, long accountId)
        {
            return 0;
        }

        private int ComputeAverageDmgToChampions(List<MatchDto> matchHistory, long accountId)
        {
            return 0;
        }

        private int ComputeAverageDmgToTurrets(List<MatchDto> matchHistory, long accountId)
        {
            return 0;

        }

        private int ComputeAverageDmgToChampionsByTeam(List<MatchDto> matchHistory, long accountId, int teamId)
        {
            return 0;
        }

        private int ComputeAverageDmgToTurretsByTeam(List<MatchDto> matchHistory, long accountId, int teamId)
        {
            return 0;
        }
    }
}