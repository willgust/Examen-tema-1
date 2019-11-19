using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class apuestas
    {
        public apuestas(int iD, string tipo, decimal cuota, decimal apostado, string correo_usuario, int iD_mercados, int esOver)
        {
            ID = iD;
            this.tipo = tipo;
            this.cuota = cuota;
            this.apostado = apostado;
            this.correo_usuario = correo_usuario;
            ID_mercados = iD_mercados;
            this.esOver = esOver;
        }

        public int ID { get; set; }
            public string tipo { get; set; }
            public decimal cuota { get; set; }
            public decimal apostado { get; set; }
            public string correo_usuario { get; set; }
            public int ID_mercados { get; set; }
            public int esOver { get; set; }

    }

    public class ApuestasDTO
    {
        public ApuestasDTO(string tipo, decimal cuota, decimal apostado, string correo_usuario, int esOver)
        {
            this.tipo = tipo;
            this.cuota = cuota;
            this.apostado = apostado;
            this.correo_usuario = correo_usuario;
            this.esOver = esOver;
            
        }

        public string tipo { get; set; }
        public decimal cuota { get; set; }
        public decimal apostado { get; set; }
        public string correo_usuario { get; set; }
        public int esOver { get; set; }
        
    }

    public class ApuestaCorreo
    {
        public ApuestaCorreo(int evento, string tipoMercado, int esOver, double cuota, double apostado)
        {
            this.evento = evento;
            this.tipoMercado = tipoMercado;
            this.esOver = esOver;
            this.cuota = cuota;
            this.apostado = apostado;
        }

        public int evento { get; set; }
        public string tipoMercado { get; set; }
        public int esOver { get; set; }
        public double cuota { get; set; }
        public double apostado { get; set; }


    }

}