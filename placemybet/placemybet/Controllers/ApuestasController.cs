using placemybet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace placemybet.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<ApuestasDTO> Get()
        {
            var repo = new apuestasRepository();
            //List<apuestas> apuesta = repo.retrieve();
            List<ApuestasDTO> apuesta = repo.retrieveDTO();
            return apuesta;
        }

        // GET: api/Apuestas?correo=correo
        public IEnumerable<ApuestaCorreo> Get(string correo) //un get q pasando un correo nos da evento, tipo de mercado (1.5, 2.5 o 3.5), tipo de apuesta (over/under), cuota y dinero apostado
        {
            var repo = new apuestasRepository();
            //List<apuestas> apuesta = repo.retrieve();
            List<ApuestaCorreo> apuesta = repo.retrieveCorreo(correo);
            return apuesta;
        }

        // GET: api/Apuestas/5
        public apuestas Get(int id)
        {
            /*var repo = new apuestasRepository();
            apuestas d = repo.retrieve();*/
            return null;
        }

        // POST: api/Apuestas
        [Authorize] //obligamos al usuario a estar autentificado xa realizar la apuesta
        public void Post([FromBody]apuestas apuesta)
        {
            var repo = new apuestasRepository();
            repo.save(apuesta);
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
