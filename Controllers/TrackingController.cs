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

namespace CovidTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        private readonly ITrackingRepository _repo;
        private readonly ILogger<TrackingController> _logger;
        public TrackingController(ITrackingRepository repo, ILogger<TrackingController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        
        [HttpGet("global")]
        public async Task<IActionResult> GetGlobalCases()
        {
            var states = await _repo.GetGlobalCasesAsync();

            if (states == null)
                return BadRequest("No data found!");
            
            return Ok(states);
        }


        [HttpGet("countries")]
        public async Task<IActionResult> GetCovidDataCountryList()
        {
            var countryList = await _repo.GetCovidDataCountryListAsync();

            if (countryList == null)
                return BadRequest("No data found!");
           
            return Ok(countryList);
        }

        [HttpGet("countries/{countryName}")]
        public async Task<IActionResult> GetSpecificCountryData(string countryName)
        {
            var country = await _repo.GetSpecificCountryDataAsync(countryName);

            if (country == null)
                return BadRequest("No data was found for this country!");

            return Ok(country);
        }
    }
}
