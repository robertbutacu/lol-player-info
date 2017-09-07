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
            gamesFed
            gamesCarried
            gamesGotCarried
            */
        public PlayerInformationDto Get(string summonerName, string region) 
        {
            DamageService damageService = new DamageService();
            SummonerDto summoner = new Summoner().GetByName(summonerName, region);
            if (summoner == null)
                return null;

            MatchlistDto matchesHistory = new Matches().Get(summoner.accountId, region);

            if (matchesHistory == null)
                return null;

            var detailedGames = GetDetailedGames(matchesHistory.matches, region);

            var playerSummary = new PlayerInformationDto
            {
                name = summoner.name,
                lanesPlayedCount = new LanesService().ComputeLanesPlayedCount(matchesHistory.matches),

                damageDealt = damageService.ComputeDamageDealtByPlayer(detailedGames, summoner.accountId),
                damageDealtByTeammates = damageService.ComputeDamageDealtByTeam(detailedGames, summoner.accountId, true),
                damageDealtByEnemies = damageService.ComputeDamageDealtByTeam(detailedGames, summoner.accountId, false)
            };

            return playerSummary;
        }
        /*
            Games carried     -> the player's dmg is the highest by a margin of 45% more than the next teammate
            Games fed         -> (kills + assists/0.70) / deaths < 1; 
            Games got carried -> fed and dmg is at least 30% less than the most dmg on the team
         */

        private List<MatchDto> GetDetailedGames(List<MatchReferenceDto> matchHistory, string region)
        {
            var detailedMatches = new List<MatchDto>();
            matchHistory.ForEach(delegate (MatchReferenceDto match)
            {
                detailedMatches.Add(new Match().GetById(match.gameId, region));
            });

            return detailedMatches;
        }
    }
}