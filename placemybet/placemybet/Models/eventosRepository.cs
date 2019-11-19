using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class eventosRepository
    {
        private static readonly String DBUser = "root";
        private static readonly String DBPwd = "";
        private MySqlConnection Connect()
        {
            string connString = "server=localhost;user=" + DBUser + ";password=" + DBPwd + ";database=placemybetarchivo2";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        //internal List<eventos> retrieve()
        //{
        //    MySqlConnection con = Connect();
        //    MySqlCommand command = con.CreateCommand();
        //    command.CommandText = "select * from eventos";

        //    con.Open();
        //    MySqlDataReader res = command.ExecuteReader();

        //    eventos d = null;
        //    List<eventos> evento = new List<eventos>();
        //    while (res.Read())
        //    {
        //        Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDateTime(1) + " " + res.GetString(2) + " " + res.GetString(3));
        //        d = new eventos(res.GetInt32(0), res.GetDateTime(1), res.GetString(2), res.GetString(3));
        //        evento.Add(d);
        //    }

        //    con.Close();
        //    return evento;
        //}
        internal List<eventosApp> retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from eventos";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            eventosApp d = null;
            List<eventosApp> eventoApp = new List<eventosApp>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + /*" " + res.GetDateTime(1)*/  " " + res.GetString(2) + " " + res.GetString(3) + " " + res.GetInt32(4));
                d = new eventosApp(res.GetInt32(0)/*, res.GetDateTime(1)*/, res.GetString(2), res.GetString(3), res.GetInt32(4));
                eventoApp.Add(d);
            }

            con.Close();
            return eventoApp;
        }

        internal List<EventosDTO> retrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from eventos";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            EventosDTO d = null;
            List<EventosDTO> evento = new List<EventosDTO>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDateTime(1) + " " + res.GetString(2) + " " + res.GetString(3));
                d = new EventosDTO(res.GetString(2), res.GetString(3));
                evento.Add(d);
            }

            con.Close();
            return evento;
        }

        internal List<MercadosDTO> retrieveByIDEvento(int ID_eventos)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercados where ID_eventos = @id";
            command.Parameters.AddWithValue("@id", ID_eventos);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                MercadosDTO d = null;
                List<MercadosDTO> mercado = new List<MercadosDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperando: " + res.GetDecimal(1) + " " + res.GetDecimal(2) + " " + res.GetDecimal(3));
                    d = new MercadosDTO(res.GetDecimal(1), res.GetDecimal(2), res.GetDecimal(3));
                    mercado.Add(d);
                }
                con.Close();
                return mercado;
            }
            catch(MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexion");
                return null;
            }
        }

    }
}