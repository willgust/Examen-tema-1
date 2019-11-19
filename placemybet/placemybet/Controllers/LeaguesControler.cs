using placemybet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace placemybet.Controllers
{
    public class LeaguesControler : ApiController
    {
        // GET: api/Leagues
        public IEnumerable<Leagues> Get()
        {
            var repo = new leaguesRepository();
            //List<eventos> evento = repo.retrieve();
            List<Leagues> League = repo.retrieve();
            return League;
        }
    }
}
