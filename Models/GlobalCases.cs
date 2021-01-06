using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerAPI.Models
{
    public record GlobalCases
    {
        public int Cases { get; init; }
        public int Deaths { get; init; }
        public int Recovered { get; init; }
    }
}
