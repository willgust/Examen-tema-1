using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class Leagues
    {
        public Leagues(string nombre, string abreviatura)
        {
            Nombre = nombre;
            Abreviatura = abreviatura;
        }

        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

    }
}