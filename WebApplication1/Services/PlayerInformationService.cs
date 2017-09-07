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

            var detailedGames = Retrieve.DetailedGames(matchesHistory.matches, region);

            var playerSummary = new PlayerInformationDto
            {
                name = summoner.name,
                lanesPlayedCount = new LanesService().ComputeLanesPlayedCount(matchesHistory.matches),
                playerScores = new ScoreService().ComputePlayerScore(detailedGames, summoner.accountId),
                gamesSummary = new GamesSummaryService().ComputeGamesSummary(detailedGames, summoner.accountId),
                damageDealt = damageService.ComputeAverageDamageDealtByPlayer(detailedGames, summoner.accountId),
                damageDealtByTeammates = damageService.ComputeDamageDealtByTeam(detailedGames, summoner.accountId, true),
                damageDealtByEnemies = damageService.ComputeDamageDealtByTeam(detailedGames, summoner.accountId, false)
            };

            return playerSummary;
        }
    }
}