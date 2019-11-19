using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class usuario
    {
        public usuario(string correo)
        {
            this.correo = correo;
        }

        public string correo { get; set; }
    }



    public class usuarioConDatos
    {
        public usuarioConDatos(string correo, int edad, string nombre, string apellido)
        {
            this.correo = correo;
            this.edad = edad;
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public string correo { get; set; }
        public int edad { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
    }
}