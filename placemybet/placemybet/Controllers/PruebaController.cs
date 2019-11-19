using placemybet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace placemybet.Controllers
{
    public class PruebaController : ApiController
    {
        // GET: api/Prueba
        public IEnumerable<Leagues> Get()
        {
            // creado xa el ejercico 1
            var repo = new leaguesRepository();
            //List<eventos> evento = repo.retrieve();
            List<Leagues> League = repo.retrieve();
            return League;
        }

        // GET: api/Prueba/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Prueba
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Prueba/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Prueba/5
        public void Delete(int id)
        {
        }
    }
}
