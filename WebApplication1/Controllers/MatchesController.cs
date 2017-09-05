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
    public class MatchesController : ApiController
    {
        public IHttpActionResult GetMatch([FromUri] long id, [FromUri] string region)
        {
            if (Array.IndexOf(Globals.REGIONS, region) != -1)
            {
                var matchDetails = new Match().GetById(id, region);
                return Ok(matchDetails);
            }
            else
                return BadRequest();
            
        }

        public IHttpActionResult GetAllMatches([FromUri] long accountId, [FromUri] string region)
        {
            if (Array.IndexOf(Globals.REGIONS, region) != -1)
            {
                var matches = new Matches().Get(accountId, region);
                return Ok(matches);
            }
            else
                return BadRequest();
        }
    }
}
