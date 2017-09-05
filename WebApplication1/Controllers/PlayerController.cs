using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class PlayerController : ApiController
    {
        public IHttpActionResult Get([FromUri] string summonerName, [FromUri] string region)
        {
            if (Array.IndexOf(Globals.REGIONS, region) == -1)
                return BadRequest();
            var playerInformation = new PlayerInformationService().Get(summonerName, region);

            if (playerInformation == null)
                return NotFound();
            else
                return Ok(playerInformation);
        }
    }
}