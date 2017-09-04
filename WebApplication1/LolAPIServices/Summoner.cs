using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.LolAPIServices
{
    public class Summoner
    {
        public SummonerDto GetByName(string summonerName, string region)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri($"https://{region}.api.riotgames.com");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync($"/lol/summoner/v3/summoners/by-name/{summonerName}?locale=en_US&dataById=false&api_key={Globals.API_KEY}").Result;

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                var modelObject = response.Content.ReadAsAsync<SummonerDto>().Result;
                return modelObject;
            }
            else
                return null;
        }
    }
}