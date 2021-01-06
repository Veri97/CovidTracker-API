using CovidTrackerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerAPI.Interfaces
{
    public interface ITrackingRepository
    {
        Task<GlobalCases> GetGlobalCasesAsync();

        Task<List<CountryData>> GetCovidDataCountryListAsync();

        Task<SpecificCountryData> GetSpecificCountryDataAsync(string countryName);
    }
}
