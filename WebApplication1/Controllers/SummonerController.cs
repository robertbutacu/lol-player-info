using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SummonerController : ApiController
    {
        public IHttpActionResult Get([FromUri] string summonerName)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://eun1.api.riotgames.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync($"/lol/summoner/v3/summoners/by-name/{summonerName}?locale=en_US&dataById=false&api_key={Globals.API_KEY}").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                var modelObject = response.Content.ReadAsAsync<SummonerDto>().Result;
                /*foreach(var champion in modelObject.data)
                {
                    System.Diagnostics.Debug.WriteLine("test");
                    System.Diagnostics.Debug.WriteLine(champion.Value.name);
                }*/
                System.Diagnostics.Debug.WriteLine("Done");
                //System.Diagnostics.Debug.WriteLine(modelObject.name);
                return Ok(modelObject);

            }
            else
                return NotFound();
        }
    }
}
