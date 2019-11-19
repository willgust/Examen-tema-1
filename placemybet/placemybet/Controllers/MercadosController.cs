using placemybet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace placemybet.Controllers
{
    public class MercadosController : ApiController
    {
        //// GET: api/Mercados
        //public IEnumerable<MercadosDTO> Get()
        //{
        //    var repo = new mercadosRepository();
        //    //List<mercados> mercado = repo.retrieve();
        //    List<MercadosDTO> mercado = repo.retrieveDTO();
        //    return mercado;
        //}

        public IEnumerable<mercados> Get()
        {
            var repo = new mercadosRepository();
            List<mercados> mercado = repo.retrieve();
            //List<MercadosDTO> mercado = repo.retrieveDTO();
            return mercado;
        }

        // GET: api/Mercados?ID_mercado=ID_mercado
        [Authorize(Roles ="Admin")]//solo los usuarios con rol admin podran usar esta funcionalidad
        public IEnumerable<MercadoID> Getmercado(int ID_mercado) //metodo xa Para un mercado concreto, recuperar todas sus apuestas. Al menos, con la siguiente informacion: email de usuario, tipo de mercado(1.5, 2.5 o 3.5), tipo de apuesta(over/under), cuota y dinero apostado.
        {
            var repo = new mercadosRepository();
            //List<mercados> mercado = repo.retrieve();
            List<MercadoID> mercado = repo.retrieveID(ID_mercado);
            return mercado;
        }


        // GET: api/Mercados/5
        public mercados Get(int id)
        {
            /*var repo = new mercadosRepository();
            mercados d = repo.retrieve();*/
            return null;
        }

        // POST: api/Mercados
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
