using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.LolAPIServices;

namespace WebApplication1.Controllers
{
    public class MatchController : ApiController
    {
        public IHttpActionResult Get([FromUri] long id, [FromUri] string region)
        {
            if (Array.IndexOf(Globals.REGIONS, region) != -1)
            {
                var matchDetails = new Match().GetById(id, region);
                return Ok(matchDetails);
            }
            else
                return BadRequest();
            
        }
    }
}
