using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class mercadosRepository
    {
        private static readonly String DBUser = "root";
        private static readonly String DBPwd = "";
        private MySqlConnection Connect()
        {
            string connString = "server=localhost;user=" + DBUser + ";password=" + DBPwd + ";database=placemybetarchivo2";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal List<mercados> retrieve()
            {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercados";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            mercados d = null;
            List<mercados> mercado = new List<mercados>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDecimal(1) + " " + res.GetDecimal(2) + " " + res.GetDecimal(3) + " " + res.GetInt32(6));
                d = new mercados(res.GetInt32(0), res.GetDecimal(1), res.GetDecimal(2), res.GetDecimal(3), res.GetInt32(6));
                mercado.Add(d);
            }

            con.Close();
            return mercado;
        }

        internal List<MercadosDTO> retrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercados";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            MercadosDTO d = null;
            List<MercadosDTO> mercado = new List<MercadosDTO>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDecimal(1) + " " + res.GetDecimal(2) + " " + res.GetDecimal(3) + " " + res.GetDecimal(4) + " " + res.GetDecimal(5) + " " + res.GetInt32(6));
                d = new MercadosDTO( res.GetDecimal(1), res.GetDecimal(2), res.GetDecimal(3));
                mercado.Add(d);
            }

            con.Close();
            return mercado;
        }

        internal List<MercadoID> retrieveID(int ID)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT apuestas.correo_usuario,mercados.tipo,apuestas.esOver,apuestas.cuota,apuestas.apostado FROM mercados INNER JOIN apuestas ON apuestas.ID_mercados=mercados.ID WHERE mercados.ID = @ID";
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                MercadoID d = null;
                List<MercadoID> mercado = new List<MercadoID>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperando: " + res.GetString(0) + " " + res.GetDecimal(1) + " " + res.GetInt32(2) + " " + res.GetDecimal(3) + " " + res.GetDecimal(4));
                    d = new MercadoID(res.GetString(0), res.GetDecimal(1), res.GetInt32(2), res.GetDecimal(3), res.GetDecimal(4));
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