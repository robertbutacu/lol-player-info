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

            /*playerScores.averageAssists = scores.averageAssists;
            playerScores.averageDeaths = scores.averageDeaths;
            playerScores.averageKills = scores.averageKills;
            */
            playerScores.averageKda = ComputeAverageKda(playerScores);


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

                var currentScores = GetPlayerScoresForCurrentMatch(match.participants, participantId);
                playerScores.AddScores(currentScores);
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
                {
                    playerScores.averageKills   = participant.stats.kills;
                    playerScores.averageAssists = participant.stats.assists;
                    playerScores.averageDeaths  = participant.stats.deaths;
                }
            });

            return playerScores;
        }

        private int GetParticipantIdForCurrentMatch(List<ParticipantIdentityDto> participantIdentities, long accountId)
        {
            int participantId = 0;
            participantIdentities.ForEach(delegate (ParticipantIdentityDto participant)
            {
                if (participant.player.accountId == accountId)
                    participantId =  participant.participantId;
            });

            return participantId;
        }

        private double ComputeAverageCreeps(List<MatchDto> matches, long accountId)
        {
            return 0;
        }
    }
}