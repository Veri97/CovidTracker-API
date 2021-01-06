using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerAPI.Models
{
    public record SpecificCountryData
    {
        public string Country { get; init; }
        public int Cases { get; init; }
        public int TodayCases { get; init; }
        public int Deaths { get; init; }
        public int TodayDeaths { get; init; }
        public int? Recovered { get; init; }
        public int? Active { get; init; }
        public int Critical { get; init; }
        public int CasesPerOneMillion { get; init; }
        public int DeathsPerOneMillion { get; init; }
        public int TotalTests { get; init; }
        public int TestsPerOneMillion { get; init; }
    }
}
