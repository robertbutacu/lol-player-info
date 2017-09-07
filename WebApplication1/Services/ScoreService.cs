using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ScoreService
    {
        public PlayerScores ComputePlayerScore(List<MatchDto> matches, long accountId)
        {
            PlayerScores playerScores = ComputePlayerKDA(matches, accountId);

            playerScores.averageKda         = ComputeAverageKda(playerScores);
            playerScores.averageCsPerMinute = ComputeAverageCreeps(matches, accountId);
            playerScores.averageCreeps      = ComputeAverageCreepsCount(matches, accountId);
            return playerScores;
        }

        private double ComputeAverageKda(PlayerScores playerScores)
        {
            return Math.Round((playerScores.averageKills + playerScores.averageAssists) / playerScores.averageDeaths, 2);
        }


        private PlayerScores ComputePlayerKDA(List<MatchDto> matches, long accountId)
        {
            PlayerScores playerScores = new PlayerScores();

            matches.ForEach(delegate (MatchDto match)
            {
                int participantId = GetParticipantIdForCurrentMatch(match.participantsIdentities, accountId);

                playerScores.AddScores(GetPlayerScoresForCurrentMatch(match.participants, participantId));
            });

            playerScores.NormalizeScores(matches.Count);

            return playerScores;
        }


        private PlayerScores GetPlayerScoresForCurrentMatch(List<ParticipantDto> participants, int participantId)
        {
            PlayerScores playerScores = new PlayerScores();
            participants.ForEach(delegate (ParticipantDto participant)
            {
                if(participant.participantId == participantId)
                    playerScores.AddScores(participant.stats.kills, participant.stats.deaths, participant.stats.assists);
            });

            return playerScores;
        }

        private int GetParticipantIdForCurrentMatch(List<ParticipantIdentityDto> participantIdentities, long accountId)
        {
            int participantId = 0;
            participantIdentities.ForEach(delegate (ParticipantIdentityDto participant)
            {
                if (participant.player.accountId == accountId)
                    participantId = participant.participantId;
            });

            return participantId;
        }

        private double ComputeAverageCreeps(List<MatchDto> matches, long accountId)
        {
            double averageCs = 0;

            matches.ForEach(delegate (MatchDto match)
            {
                int participantId = GetParticipantIdForCurrentMatch(match.participantsIdentities, accountId);
                averageCs        += ComputeAverageCSForCurrentMatch(match.participants, participantId);
            });

            return Math.Round(averageCs / matches.Count, 2);
        }

        private double ComputeAverageCreepsCount(List<MatchDto> matches, long accountId)
        {
            double averageCsCount = 0;

            matches.ForEach(delegate (MatchDto match)
            {
                int participantId = GetParticipantIdForCurrentMatch(match.participantsIdentities, accountId);
                averageCsCount   += GetCsForCurrentMatch(match.participants, participantId);
            });

            return Math.Round(averageCsCount / matches.Count, 2);
        }

        private double GetCsForCurrentMatch(List<ParticipantDto> participants, int participantId)
        {
            double cs = 0;

            participants.ForEach(delegate (ParticipantDto participant)
            {
                if (participant.participantId == participantId)
                    cs = participant.stats.totalMinionsKilled + participant.stats.neutralMinionsKilled;
            });

            return cs;
        }

        private double ComputeAverageCSForCurrentMatch(List<ParticipantDto> participants, int participantId)
        {
            double cs = 0;
            participants.ForEach(delegate (ParticipantDto participant)
            {
                if(participant.participantId == participantId)
                    cs = participant.timeline.creepsPerMinDeltas.Values.Average();
            });

            return cs;
        }
    }
}