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
            averageCsPerMinute
            gamesFed
            gamesCarried
            gamesGotCarried
            averageDmgToChampions
            averageDmgToTurrets
            averageDmgToChampionsEnemies
            averageDmgToTurretsEnemies
            averageDmgToTurretsTeammates
            averageDmgToChampionsTeammates
            */
        public PlayerInformationDto Get(string summonerName, string region) 
        {
            SummonerDto summoner = new Summoner().GetByName(summonerName, region);
            if (summoner == null)
                return null;

            MatchlistDto matchesHistory = new Matches().Get(summoner.accountId, region);

            if (matchesHistory == null)
                return null;

            var detailedGames = GetDetailedGames(matchesHistory.matches, region);

            var averageStats = ComputeAverageStats(detailedGames, summoner.accountId, matchesHistory.totalGames);
            var playerSummary = new PlayerInformationDto
            {
                name = summoner.name,
                lanesPlayedCount = ComputeLanesPlayedCount(matchesHistory.matches),

                playerScores = averageStats.Item1,
                damageDealt = averageStats.Item2,
                damageDealtByTeammates = averageStats.Item3,
                damageDealtByEnemies = averageStats.Item4
            };

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

        private Tuple<PlayerScores, DamageDealt, DamageDealt, DamageDealt> ComputeAverageStats(List<MatchDto> matchHistory, long accountId, int numberOfGames)
        {
            PlayerScores playerScores = new PlayerScores();
            DamageDealt averageDamageByPlayer   = new DamageDealt();
            DamageDealt averageDamageByTeam     = new DamageDealt();
            DamageDealt averageDamageByEnemeies = new DamageDealt();

            matchHistory.ForEach(delegate (MatchDto match)
            {
                int participantId = 0;
                int teamId = 0;
                match.participantsIdentities.ForEach(delegate (ParticipantIdentityDto participantIdentityDto)
                {
                    if (participantIdentityDto.player.accountId == accountId)
                        participantId = participantIdentityDto.participantId;
                });
                match.participants.ForEach(delegate (ParticipantDto participant)
                {
                    if (participant.participantId == participantId)
                    {
                        playerScores.averageKills   += participant.stats.kills;
                        playerScores.averageDeaths  += participant.stats.deaths;
                        playerScores.averageAssists += participant.stats.assists;
                        averageDamageByPlayer.averageDmgToChampions += participant.stats.totalDamageDealtToChampions;
                        averageDamageByPlayer.averageDmgToTurrets   += participant.stats.damageDealtToTurrets;
                        teamId = participant.teamId;
                    } 
                });
                var damageStats = ComputeDamageStats(match.participants, participantId, teamId);
                averageDamageByTeam     = damageStats.Item1;
                averageDamageByEnemeies = damageStats.Item2;
            });

            return new Tuple<PlayerScores, DamageDealt, DamageDealt, DamageDealt>(
                playerScores,
                averageDamageByPlayer,
                averageDamageByTeam,
                averageDamageByEnemeies
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

        private Tuple<DamageDealt, DamageDealt> ComputeDamageStats(List<ParticipantDto> matchStats, int participantId, int teamId)
        {
            DamageDealt dmgDealtByTeam    = new DamageDealt();
            DamageDealt dmgDealtByEnemies = new DamageDealt();

            matchStats.ForEach(delegate (ParticipantDto participant)
            {
                if (participant.teamId == teamId && participant.participantId != participantId)
                {
                    dmgDealtByTeam.averageDmgToChampions += participant.stats.totalDamageDealtToChampions;
                    dmgDealtByTeam.averageDmgToTurrets   += participant.stats.damageDealtToTurrets;
                }
                else
                {
                    dmgDealtByEnemies.averageDmgToChampions += participant.stats.totalDamageDealtToChampions;
                    dmgDealtByEnemies.averageDmgToTurrets   += participant.stats.damageDealtToTurrets;
                }
            });

            return new Tuple<DamageDealt, DamageDealt>(dmgDealtByTeam, dmgDealtByEnemies);
        }
    }
}