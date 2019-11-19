using placemybet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace placemybet.Controllers
{
    public class EventosController : ApiController
    {
        // GET: api/Eventos
        public IEnumerable<eventosApp> Get()
        {
            var repo = new eventosRepository();
            //List<eventos> evento = repo.retrieve();
            List<eventosApp> evento = repo.retrieve();
            return evento;
        }

        // GET: api/Eventos?ID_eventos=ID_eventos
        public IEnumerable<MercadosDTO> Getevento(int ID_eventos) // metodo xa mostrar los mercados vinculados a la id de eventos
        {
            var repo = new eventosRepository();
            //List<eventos> evento = repo.retrieve();
            List<MercadosDTO> mercado = repo.retrieveByIDEvento(ID_eventos);
            return mercado;
        }

        // GET: api/Eventos/5
        public eventos Get(int id)
        {
            /*var repo = new eventosRepository();
            eventos d = repo.retrieve();*/
            return null;
        }

        // POST: api/Eventos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
        }
    }
}
