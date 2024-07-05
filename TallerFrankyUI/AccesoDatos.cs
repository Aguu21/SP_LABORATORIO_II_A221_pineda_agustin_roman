using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Parcial.WindowsForm
{
    public static class AccesoDatos
    {
        private static SqlCommand command;
        private static SqlConnection connection;
        private static string connectionString = $"server=localhost;user id=root;password=;database=parcial2;";
        private static void AccesoDato() 
        {
            using (var connect = new MySqlConnection(connectionString)) 
            {
                connect.Open();
                string query = "SELECT * FROM tablaparcial";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var empleado = new Usuario
                    {
                        Id = reader.GetInt32("id"),
                        Nombre = reader.GetString("nombre"),
                        Edad = reader.GetInt32("edad"),
                        Fecha = reader.GetDateTime("fecha")
                    };
                }
            }
        }

        public static bool Guardar(string nombre, int costo)
        {
            try
            {
                using (var connect = new MySqlConnection(connectionString))
                {
                    connect.Open();
                    string query = "INSERT INTO tablaparcial (mensaje, alumno)" +
                        $"VALUES (@mensjae, @alumno)";
                    MySqlCommand cmd = new MySqlCommand(query, connect);
                    
                    cmd.Parameters.AddWithValue("@mensaje", $"Se reparó el " +
                        $"{nombre} a un costo de {costo} berries.");

                    cmd.Parameters.AddWithValue("@alumno", "Agustín Román " +
                        "Pineda");
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
