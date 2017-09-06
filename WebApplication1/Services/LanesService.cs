using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class LanesService
    {
        public Dictionary<string, int> ComputeLanesPlayedCount(List<MatchReferenceDto> matchHistory)
        {
            var lanesPlayedCount = new Dictionary<string, int>();
            lanesPlayedCount.Add("MID", 0);
            lanesPlayedCount.Add("JUNGLE", 0);
            lanesPlayedCount.Add("TOP", 0);
            lanesPlayedCount.Add("SUPPORT", 0);
            lanesPlayedCount.Add("ADC", 0);

            matchHistory.ForEach(delegate (MatchReferenceDto match)
            {
                if (match.lane == "BOTTOM" && match.role == "DUO_SUPPORT")
                    lanesPlayedCount["SUPPORT"] += 1;
                if (match.lane == "BOTTOM" && match.role != "DUO_SUPPORT")
                    lanesPlayedCount["ADC"] += 1;
                if (match.lane != "BOTTOM")
                    lanesPlayedCount[match.lane] += 1;
            });

            return lanesPlayedCount;
        }
    }
}