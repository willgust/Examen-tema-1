using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class usuarioRepository
    {
        private static readonly String DBUser = "root";
        private static readonly String DBPwd = "";
        private MySqlConnection Connect()
        {
            string connString = "server=localhost;user=" + DBUser + ";password=" + DBPwd + ";database=placemybetarchivo2";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<usuario> retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from usuarios";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            usuario d = null;
            List<usuario> eventoApp = new List<usuario>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetString(0));
                d = new usuario(res.GetString(0));
                eventoApp.Add(d);
            }

            con.Close();
            return eventoApp;
        }

        internal List<usuario> retrieveCorreo(string correo)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from usuarios where correo = @correo"; /*SELECT* FROM `usuarios` WHERE usuarios.correo = "algo1@gmail.com"*/
            command.Parameters.AddWithValue("@correo", correo);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                usuario d = null;
                List<usuario> usuario = new List<usuario>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperando: " + res.GetString(0) );
                    d = new usuario(res.GetString(0));
                    usuario.Add(d);
                }
                con.Close();
                return usuario;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexion");
                return null;
            }
        }

        internal List<usuarioConDatos> retrieveCorreoConDatos(string correo)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from usuarios where correo = @correo"; /*SELECT* FROM `usuarios` WHERE usuarios.correo = "algo1@gmail.com"*/
            command.Parameters.AddWithValue("@correo", correo);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                usuarioConDatos d = null;
                List<usuarioConDatos> usuario = new List<usuarioConDatos>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperando: " + res.GetString(0) + " " + res.GetInt32(1) + " " + res.GetString(2) + " " + res.GetString(3));
                    d = new usuarioConDatos(res.GetString(0), res.GetInt32(1), res.GetString(2), res.GetString(3));
                    usuario.Add(d);
                }
                con.Close();
                return usuario;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexion");
                return null;
            }
        }
    }
}