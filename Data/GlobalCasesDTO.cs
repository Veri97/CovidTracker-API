using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerAPI.Data
{
    public record GlobalCasesDTO
    {
        public int Cases { get; init; }
        public int Deaths { get; init; }
        public int Recovered { get; init; }
    }
}
