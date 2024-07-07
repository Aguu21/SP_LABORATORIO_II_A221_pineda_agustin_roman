using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Parcial.WindowsForm
{
    public static class AccesoDatos
    {
        private static MySqlCommand command;
        private static MySqlConnection connection;
        private static string connectionString = 
            $"server=localhost;user id=root;password=;database=parcial2;";
        static AccesoDatos() 
        {
            connection = new MySqlConnection(connectionString);
            command = new MySqlCommand();
            command.Connection = connection;
        }

        public static bool Guardar(string nombre, float costo)
        {
            try
            {
                connection.Open();
                command.CommandText = $"INSERT INTO registros " +
                    $"(mensaje, alumno) VALUES (@mensaje, @alumno)";
                command.Parameters.AddWithValue("@mensaje",
                    $"Se reparó el {nombre} a un costo de {costo} " +
                    $"berries");
                command.Parameters.AddWithValue("@alumno",
                    "Agustín Román Pineda");
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                return false;
            }
        }
    }
}
