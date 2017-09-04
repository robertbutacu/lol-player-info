using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApplication1.LolAPIServices;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SummonerController : ApiController
    {
        public IHttpActionResult Get([FromUri] string summonerName,[FromUri] string region)
        {
            if (Array.IndexOf(Globals.REGIONS, region) != 1)
            {
                var summoner = new Summoner().GetByName(summonerName, region);
                return Ok(summoner);
            }
            else
                return BadRequest();

        }
    }
}
