using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class DamageService
    {
        public DamageDealt GetDamageDealtByTeam(List<MatchDto> matches, long accountId, Boolean isPlayerTeam)
        {
            DamageDealt dmgDealtByTeam = new DamageDealt();

            matches.ForEach(delegate (MatchDto match)
            {
                int playerParticipantId = GetPlayerParticipantId(match.participantsIdentities, accountId);

                int playerTeamId = GetPlayerTeamId(match.participants, playerParticipantId);

                dmgDealtByTeam = ComputeDamageDealtByTeam(match.participants, playerTeamId, playerParticipantId);
                dmgDealtByTeam = NormalizeDamage(dmgDealtByTeam, matches.Count, isPlayerTeam ? true : false);
            });

            return dmgDealtByTeam;
        }


        public DamageService ComputeDamageDealtByPlayer(List<MatchDto> matches, long accountId)
        {
            return null;
        }


        private DamageDealt ComputeDamageDealtByTeam(List<ParticipantDto> participants, int teamId, int playerParticipantId)
        {
            DamageDealt dmgDealt = new DamageDealt();
            participants.ForEach(delegate (ParticipantDto participant)
            {
                if (participant.teamId == teamId && participant.participantId != playerParticipantId)
                {
                    dmgDealt.averageDmgToChampions += participant.stats.totalDamageDealtToChampions;
                    dmgDealt.averageDmgToTurrets += participant.stats.damageDealtToTurrets;
                }
            });

            return dmgDealt;
        }


        private DamageDealt NormalizeDamage(DamageDealt dmgDealt, int totalGames, Boolean isPlayerTeam)
        {
            int factor = isPlayerTeam ? 4 : 5;

            dmgDealt.averageDmgToChampions /= (factor * totalGames);
            dmgDealt.averageDmgToTurrets /= (factor * totalGames);

            return dmgDealt;
        }


        private int GetPlayerTeamId(List<ParticipantDto> participants, int participantId)
        {
            int teamId = 0;
            participants.ForEach(delegate (ParticipantDto participant)
            {
                if (participant.participantId == participantId)
                    teamId = participant.teamId;
            });

            return teamId;
        }


        private int GetPlayerParticipantId(List<ParticipantIdentityDto> participants, long accountId)
        {
            int playerParticipantId = 0;
            participants.ForEach(delegate (ParticipantIdentityDto participant)
            {
                if (participant.player.accountId == accountId)
                    playerParticipantId = participant.participantId;
            });

            return playerParticipantId;
        }

    }
}