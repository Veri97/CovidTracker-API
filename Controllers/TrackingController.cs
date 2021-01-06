using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidTrackerAPI.Helpers;
using CovidTrackerAPI.Interfaces;
using CovidTrackerAPI.Models;
using Microsoft.Extensions.Logging;
using AutoMapper;
using CovidTrackerAPI.Data;

namespace CovidTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        private readonly ITrackingRepository _repo;
        private readonly ILogger<TrackingController> _logger;
        private readonly IMapper _mapper;

        public TrackingController(ITrackingRepository repo, ILogger<TrackingController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        
        [HttpGet("global")]
        public async Task<IActionResult> GetGlobalCases()
        {
            var globalCases = await _repo.GetGlobalCasesAsync();

            if (globalCases == null)
                return BadRequest("No data found!");

            var globalCasesToReturn = _mapper.Map<GlobalCasesDTO>(globalCases);

            return Ok(globalCasesToReturn);
        }


        [HttpGet("countries")]
        public async Task<IActionResult> GetCovidDataCountryList()
        {
            var countryList = await _repo.GetCovidDataCountryListAsync();

            if (countryList == null)
                return BadRequest("No data found!");

            var countryListToReturn = _mapper.Map<List<CountryDataDTO>>(countryList);

            return Ok(countryListToReturn);
        }

        [HttpGet("countries/{countryName}")]
        public async Task<IActionResult> GetSpecificCountryData(string countryName)
        {
            var country = await _repo.GetSpecificCountryDataAsync(countryName);

            if (country == null)
                return BadRequest("No data was found for this country!");

            var countryToReturn = _mapper.Map<SpecificCountryDataDTO>(country);

            return Ok(countryToReturn);
        }
    }
}
