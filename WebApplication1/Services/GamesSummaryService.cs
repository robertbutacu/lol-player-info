using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    /*
    Games carried     -> the player's dmg is the highest by a margin of 45% more than the next teammate
    Games fed         -> (kills + assists/0.70) / deaths < 1; 
    Games got carried -> fed and dmg is at least 30% less than the most dmg on the team
    */
    public class GamesSummaryService
    {
        public GamesSummary ComputeGamesSummary(List<MatchDto> matchHistory, long accountId)
        {
            GamesSummary gamesSummary = new GamesSummary();
            DamageDealt byPlayer = new DamageDealt();
            DamageDealt highestInTeam = new DamageDealt();
            PlayerScores playerScores = new PlayerScores();

            ScoreService scoreService = new ScoreService();

            DamageService damageService = new DamageService();

            matchHistory.ForEach(delegate (MatchDto match)
            {
                int participantId = Retrieve.ParticipantIdForCurrentMatch(match.participantsIdentities, accountId);
                int teamId = Retrieve.PlayerTeamId(match.participants, participantId);

                Boolean hasWon = HasWon(match.participants, participantId);
                
                playerScores.ReplaceScores(scoreService.GetPlayerScoresForCurrentMatch(match.participants, participantId));

                byPlayer.ReplaceDamage(damageService.ComputeDamageDealtByPlayer(match.participants, participantId));
                highestInTeam.ReplaceDamage(damageService.GetHighestDamageDealerInTeam(match.participants, participantId, teamId));
                gamesSummary.Add(
                    HasCarried(byPlayer, highestInTeam, hasWon) ? 1 : 0,
                    HasFed(playerScores) ? 1 : 0,
                    HasGottenCarried(playerScores, byPlayer, highestInTeam, hasWon) ? 1 : 0
                    );
            });

            return gamesSummary;

        }

        private Boolean HasWon(List<ParticipantDto> participants, int participantId)
        {
            Boolean hasWon = false;
            participants.ForEach(delegate(ParticipantDto p)
            {
                if (p.participantId == participantId)
                    hasWon = p.stats.win;
            });

            return hasWon;
        }


        private Boolean HasFed(PlayerScores playerScores)
        {
            return ((playerScores.averageKills + playerScores.averageAssists * 0.70) / playerScores.averageDeaths) < 1;
        }

        private Boolean HasCarried(DamageDealt byPlayer, DamageDealt highestInTeam, Boolean hasWon)
        {
            System.Diagnostics.Debug.WriteLine(byPlayer.averageDmgToChampions + " " + highestInTeam.averageDmgToChampions * 1.45);
            return hasWon && byPlayer.averageDmgToChampions > (highestInTeam.averageDmgToChampions * 1.45);
        }

        private Boolean HasGottenCarried(PlayerScores playerScores, DamageDealt byPlayer, DamageDealt highestInTeam, Boolean hasWon)
        {
            return hasWon && 
                !HasFed(playerScores) && 
                (byPlayer.averageDmgToChampions * 1.30 < highestInTeam.averageDmgToChampions);
        }
    }
}