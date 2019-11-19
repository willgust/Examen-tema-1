using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class mercados
    {
        public mercados(int iD, decimal tipo, decimal cuotaOver, decimal cuotaUnder, int iD_eventos)
        {
            ID = iD;
            this.tipo = tipo;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            ID_eventos = iD_eventos;
        }

        //public mercados(int iD, decimal tipo, decimal cuotaOver, decimal cuotaUnder, decimal apostadoOver, decimal apostadoUnder, int iD_eventos)
        //{
        //    ID = iD;
        //    this.tipo = tipo;
        //    this.cuotaOver = cuotaOver;
        //    this.cuotaUnder = cuotaUnder;
        //    this.apostadoOver = apostadoOver;
        //    this.apostadoUnder = apostadoUnder;
        //    ID_eventos = iD_eventos;
        //}

        public int ID { get; set; }
        public decimal tipo { get; set; }
        public decimal cuotaOver { get; set; }
        public decimal cuotaUnder { get; set; }
        //public decimal apostadoOver { get; set; }
        //public decimal apostadoUnder { get; set; }
        public int ID_eventos { get; set; }

    }

    public class MercadosDTO
    {
        public MercadosDTO(decimal tipo, decimal cuotaOver, decimal cuotaUnder)
        {
            
            this.tipo = tipo;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            
        }

        
        public decimal tipo { get; set; }
        public decimal cuotaOver { get; set; }
        public decimal cuotaUnder { get; set; }

       
    }

    public class MercadoID
    {
        public MercadoID(string correo, decimal tipo, int esOver, decimal cuota, decimal apostados)
        {
            this.correo = correo;
            this.tipo = tipo;
            this.esOver = esOver;
            this.cuota = cuota;
            this.apostados = apostados;
        }

        public string correo { get; set; }
        public decimal tipo { get; set; }
        public int esOver { get; set; }
        public decimal cuota { get; set; }
        public decimal apostados { get; set; }
    }

    public class MercadosApi
    {
        public MercadosApi(decimal tipo, decimal cuotaOver, decimal cuotaUnder, int iD_eventos)
        {
            this.tipo = tipo;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            ID_eventos = iD_eventos;
        }

        public decimal tipo { get; set; }
        public decimal cuotaOver { get; set; }
        public decimal cuotaUnder { get; set; }
        public int ID_eventos { get; set; }


    }
}
