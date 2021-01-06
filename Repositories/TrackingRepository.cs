using CovidTrackerAPI.Interfaces;
using CovidTrackerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using CovidTrackerAPI.Helpers;

namespace CovidTrackerAPI.Repositories
{
    public class TrackingRepository : ITrackingRepository
    {
        private readonly string API_URL = Constants.API_URL;

        public async Task<GlobalCases> GetGlobalCasesAsync()
        {
            var client = new RestClient($"{API_URL}/all");
            var request = new RestRequest(Method.GET);

            IRestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<GlobalCases>(response.Content);
            }

            return null;
        }



        public async Task<List<CountryData>> GetCovidDataCountryListAsync()
        {
            var client = new RestClient($"{API_URL}/countries");
            var request = new RestRequest(Method.GET);

            IRestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<CountryData>>(response.Content);
            }

            return null;
        }

        public async Task<SpecificCountryData> GetSpecificCountryDataAsync(string countryName)
        {
            var client = new RestClient($"{API_URL}/countries/{countryName}");
            var request = new RestRequest(Method.GET);

            IRestResponse response = await client.ExecuteAsync(request);

            if (response.Content.Equals("Country not found") || !response.IsSuccessful)
                return null;

            return JsonConvert.DeserializeObject<SpecificCountryData>(response.Content);

        }
    }
}
