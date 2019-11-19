using placemybet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace placemybet.Controllers
{
    public class usuarioController : ApiController
    {
        // GET: api/Usuario
        public IEnumerable<usuario> Get()
        {
            var repo = new usuarioRepository();
            //List<eventos> evento = repo.retrieve();
            List<usuario> usuario = repo.retrieve();
            return usuario;
        }

        // GET: api/Usuario?correo=correo
        public IEnumerable<usuario> Getevento(string correo) // metodo xa mostrar los usuarios vinculados al correo
        {
            var repo = new usuarioRepository();
            //List<eventos> evento = repo.retrieve();
            List<usuario> usuarios = repo.retrieveCorreo(correo);
            return usuarios;
        }

        // GET: api/Usuario?OtroCon=correo
        public IEnumerable<usuarioConDatos> Geteventos(string Otrocorreo) // metodo xa mostrar los usuarios vinculados al correo
        {
            Debug.WriteLine("entro en otro correo");
            var repo = new usuarioRepository();
            //List<eventos> evento = repo.retrieve();
            List<usuarioConDatos> usuarios = repo.retrieveCorreoConDatos(Otrocorreo);
            return usuarios;
        }

        //// GET: api/Eventos/5
        //public eventos Get(int id)
        //{
        //    /*var repo = new eventosRepository();
        //    eventos d = repo.retrieve();*/
        //    return null;
        //}

        //// POST: api/Eventos
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Eventos/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Eventos/5
        //public void Delete(int id)
        //{
        //}
    }
}