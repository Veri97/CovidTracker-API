using AutoMapper;
using CovidTrackerAPI.Data;
using CovidTrackerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GlobalCases, GlobalCasesDTO>();
            CreateMap<CountryData, CountryDataListDTO>();
            CreateMap<SpecificCountryData, SpecificCountryDataDTO>();
        }
    }
}
