using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class leaguesRepository
    {
        private static readonly String DBUser = "examen";
        private static readonly String DBPwd = "examen";
        private MySqlConnection Connect()
        {
            string connString = "server=34.219.191.133;Port=3306;user=" + DBUser + ";password=" + DBPwd + ";database=placemybet";

            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        //metodo xa recuperar los datos de la liga
        internal List<Leagues> retrieve()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from leagues";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Leagues d = null;
            List<Leagues> league = new List<Leagues>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetString(3));
                d = new Leagues(res.GetString(1), res.GetString(3));
                league.Add(d);
            }

            con.Close();
            return league;
        }
    }
}