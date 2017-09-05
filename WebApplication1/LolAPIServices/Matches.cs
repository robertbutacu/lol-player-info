using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.LolAPIServices
{
    public class Matches
    {
        public MatchlistDto Get(long accountId, string region)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri($"https://{region}.api.riotgames.com");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync($"lol/match/v3/matchlists/by-account/{accountId}?beginIndex=0&endIndex=100&api_key={Globals.API_KEY}").Result;

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                var modelObject = response.Content.ReadAsAsync<MatchlistDto>().Result;

                return modelObject;
            }
            else
                return null;
        }
    }
}