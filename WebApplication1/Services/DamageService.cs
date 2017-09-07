using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class DamageService
    {
        public DamageDealt ComputeDamageDealtByTeam(List<MatchDto> matches, long accountId, Boolean isPlayerTeam)
        {
            DamageDealt dmgDealtByTeam = new DamageDealt();

            matches.ForEach(delegate (MatchDto match)
            {
                int playerParticipantId = GetPlayerParticipantId(match.participantsIdentities, accountId);

                int playerTeamId = GetPlayerTeamId(match.participants, playerParticipantId);

                dmgDealtByTeam.Add(ComputeDamageDealtByTeam(match.participants, playerTeamId, playerParticipantId));

            });

            dmgDealtByTeam.Normalize(matches.Count * (isPlayerTeam ? 4 : 5));

            return dmgDealtByTeam;
        }


        public DamageDealt ComputeDamageDealtByPlayer(List<MatchDto> matches, long accountId)
        {
            DamageDealt dmgDealtByPlayer = new DamageDealt();
            int totalGames = matches.Count;

            matches.ForEach(delegate (MatchDto match)
            {
                int playerParticipantId = GetPlayerParticipantId(match.participantsIdentities, accountId);

                dmgDealtByPlayer.Add(ComputeDamageDealtByPlayer(match.participants, playerParticipantId, totalGames));
            });

            dmgDealtByPlayer.Normalize(matches.Count);

            return dmgDealtByPlayer;
        }


        private DamageDealt ComputeDamageDealtByPlayer(List<ParticipantDto> participants, int participantId, int totalGames)
        {
            DamageDealt dmg = new DamageDealt();

            participants.ForEach(delegate (ParticipantDto participant)
            {
                if (participant.participantId == participantId)
                    dmg.Add(participant.stats.totalDamageDealtToChampions, participant.stats.damageDealtToTurrets);
            });

            return dmg;
        }


        private DamageDealt ComputeDamageDealtByTeam(List<ParticipantDto> participants, int teamId, int playerParticipantId)
        {
            DamageDealt dmgDealt = new DamageDealt();
            participants.ForEach(delegate (ParticipantDto participant)
            {
                if (participant.teamId == teamId && participant.participantId != playerParticipantId)
                    dmgDealt.Add(participant.stats.totalDamageDealtToChampions, participant.stats.damageDealtToTurrets);
            });

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