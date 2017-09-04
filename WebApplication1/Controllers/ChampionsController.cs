﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ChampionsController : ApiController
    {
        public IHttpActionResult Get()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eun1.api.riotgames.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("/lol/static-data/v3/champions?locale=en_US&dataById=false&api_key=RGAPI-800a7ddf-58cf-4c31-96e9-2489c641bcbb").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                var modelObject = response.Content.ReadAsAsync<ChampionsListDto>().Result;
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
