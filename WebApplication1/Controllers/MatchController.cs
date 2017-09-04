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
    public class MatchController : ApiController
    {
        public IHttpActionResult Get([FromUri] long id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eun1.api.riotgames.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync($"lol/match/v3/matches/{id}?api_key={Globals.API_KEY}").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                var modelObject = response.Content.ReadAsAsync<MatchDto>().Result;
                /*foreach(var champion in modelObject.data)
                {
                    System.Diagnostics.Debug.WriteLine("test");
                    System.Diagnostics.Debug.WriteLine(champion.Value.name);
                }*/
                System.Diagnostics.Debug.WriteLine("test");
                return Ok(modelObject);
            }
            else
                return NotFound();
        }
    }
}
