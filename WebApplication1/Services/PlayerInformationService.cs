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
            if (summoner == null)
                return null;

            MatchlistDto matchesHistory = new Matches().Get(summoner.accountId, region);

            if (matchesHistory == null)
                return null;

            var playerSummary =  new PlayerInformationDto();

            playerSummary.name = summoner.name;
            playerSummary.lanesPlayedCount = ComputeLanesPlayedCount(matchesHistory.matches);

            var detailedGames = GetDetailedGames(matchesHistory.matches, region);

            var playerScores = GetPlayerScores(detailedGames, summoner.accountId, matchesHistory.totalGames);


            playerSummary.playerScores = playerScores;

            return playerSummary;
        }
        /*
            Games carried     -> the player's dmg is the highest.
            Games fed         -> (kills + assists/0.70) / deaths < 1; 
            Games got carried -> 
         */

        private PlayerScores GetPlayerScores(List<MatchDto> detailedGames, long accountId, int totalGames)
        {
            var playerScores = new PlayerScores();
            var scores = ComputePlayerScores(detailedGames, accountId, totalGames);

            playerScores.averageKills = scores.Item1;
            playerScores.averageDeaths = scores.Item2;
            playerScores.averageAssists = scores.Item3;

            playerScores.averageKda = Math.Round((playerScores.averageKills + playerScores.averageAssists) / playerScores.averageDeaths, 2);

            return playerScores;
        }

        private List<MatchDto> GetDetailedGames(List<MatchReferenceDto> matchHistory, string region)
        {
            var detailedMatches = new List<MatchDto>();
            matchHistory.ForEach(delegate (MatchReferenceDto match)
            {
                detailedMatches.Add(new Match().GetById(match.gameId, region));
            });

            return detailedMatches;
        }

        private Dictionary<string, int> ComputeLanesPlayedCount(List<MatchReferenceDto> matchHistory)
        {
            var lanesPlayedCount = new Dictionary<string, int>();
            lanesPlayedCount.Add("MID", 0);
            lanesPlayedCount.Add("JUNGLE", 0);
            lanesPlayedCount.Add("TOP", 0);
            lanesPlayedCount.Add("SUPPORT", 0);
            lanesPlayedCount.Add("ADC", 0);

            matchHistory.ForEach(delegate(MatchReferenceDto match)
                {
                if(match.lane == "BOTTOM" && match.role == "DUO_SUPPORT")
                        lanesPlayedCount["SUPPORT"] += 1;
                if(match.lane == "BOTTOM" && match.role != "DUO_SUPPORT")
                        lanesPlayedCount["ADC"] +=1;
                if (match.lane != "BOTTOM")
                        lanesPlayedCount[match.lane] += 1;
                });

            return lanesPlayedCount;
        }

        private Tuple<double, double, double> ComputePlayerScores(List<MatchDto> matchHistory, long accountId, int numberOfGames)
        {
            int kills = 0, deaths = 0, assists = 0;
            matchHistory.ForEach(delegate (MatchDto match)
            {
                int participantId = 0;
                match.participantsIdentities.ForEach(delegate (ParticipantIdentityDto participantIdentityDto)
                {
                    if (participantIdentityDto.player.accountId == accountId)
                        participantId = participantIdentityDto.participantId;
                });
                match.participants.ForEach(delegate (ParticipantDto participant)
                {
                    if (participant.participantId == participantId)
                    {
                        kills   += participant.stats.kills;
                        deaths  += participant.stats.deaths;
                        assists += participant.stats.assists;
                    } 
                });
            });

            return new Tuple<double, double, double>(
                Math.Round(System.Convert.ToDouble(kills)   / System.Convert.ToDouble(numberOfGames) * 10, 2),
                Math.Round(System.Convert.ToDouble(deaths)  / System.Convert.ToDouble(numberOfGames) * 10, 2),
                Math.Round(System.Convert.ToDouble(assists) / System.Convert.ToDouble(numberOfGames) * 10, 2)
                );
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