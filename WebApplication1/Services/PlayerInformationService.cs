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

            var playerScores = new PlayerScores();
            playerScores.averageDeaths = ComputeAverageDeaths(detailedGames, summoner.accountId, matchesHistory.totalGames);
            playerScores.averageAssists = ComputeAverageAssists(detailedGames, summoner.accountId, matchesHistory.totalGames);
            playerScores.averageKills = ComputeAverageKills(detailedGames, summoner.accountId, matchesHistory.totalGames);
            playerScores.averageKda = Math.Round((playerScores.averageKills + playerScores.averageAssists) / playerScores.averageDeaths,2);


            playerSummary.playerScores = playerScores;

            return playerSummary;
        }
        /*
            Games carried     -> the player's dmg is the highest.
            Games fed         -> (kills + assists/0.70) / deaths < 1; 
            Games got carried -> 
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

        private double ComputeAverageKills(List<MatchDto> matchHistory, long accountId, int numberOfGames)
        {
            int kills = 0;
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
                        kills += participant.stats.kills;
                });
            });

            return Math.Round(System.Convert.ToDouble(kills) / System.Convert.ToDouble(numberOfGames) * 10, 2);
        }

        private double ComputeAverageDeaths(List<MatchDto> matchHistory, long accountId, int numberOfGames)
        {
            int deaths = 0;
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
                        deaths += participant.stats.deaths;
                });
            });

            return Math.Round(System.Convert.ToDouble(deaths) / System.Convert.ToDouble(numberOfGames) * 10, 2);
        }

        private double ComputeAverageAssists(List<MatchDto> matchHistory, long accountId, int numberOfGames)
        {
            int assists = 0;
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
                        assists += participant.stats.assists;
                });
            });
            
            return Math.Round(System.Convert.ToDouble(assists) / System.Convert.ToDouble(numberOfGames) * 10, 2);
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